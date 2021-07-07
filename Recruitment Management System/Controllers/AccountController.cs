using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RMSLibrary.Models;
using RMSLibrary.Models.DBModel;
using Recruitment_Management_System.Interfaces;
using Microsoft.AspNetCore.Cors;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace Recruitment_Management_System.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Account")]
    [EnableCors("ReactPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext databaseContext;
        private readonly IAccountRepository accountRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountController(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager
            , SignInManager<IdentityUser> signInManager
            , IConfiguration configuration
            , ApplicationDbContext applicationDbContext
            , IAccountRepository accountRepository
            , IWebHostEnvironment hostEnvironment)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _configuration = configuration;
            databaseContext = applicationDbContext;
            this.accountRepository = accountRepository;

            this._hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password)
                && (await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
            {
                RefreshTokenModel refreshTokenModel = await GenerateAccessToken(user);
                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    success = true,
                    status= StatusCodes.Status200OK,
                    token = refreshTokenModel.Token,
                    refreshToken = refreshTokenModel.RefreshToken,
                    expiration = refreshTokenModel.Expiration
                });;
            }

            return Unauthorized();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("AdminLogin")]
        public async Task<IActionResult> AdminLogin([FromBody] Login loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password)
                && (await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
            {
                IdentityUser admin = null;
                var admins = await userManager.GetUsersInRoleAsync("Admin");
                admin = admins.FirstOrDefault(x => x.Id == user.Id);
                if (admin != null)
                {
                    RefreshTokenModel refreshTokenModel = await GenerateAccessToken(user);
                    return Ok(new
                    {
                        user.Id,
                        user.UserName,
                        success = true,
                        status = StatusCodes.Status200OK,
                        token = refreshTokenModel.Token,
                        refreshToken = refreshTokenModel.RefreshToken,
                        expiration = refreshTokenModel.Expiration
                    });
                }
            }

            return Unauthorized();
        }

        private async Task<RefreshTokenModel> GenerateAccessToken(IdentityUser user)
        {
            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id)
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(120),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var refreshTokenModel = new RefreshTokenModel
            {
                RefreshToken = (await GenerateRefreshToken(user.Id, token.Id)).Token,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };

            return refreshTokenModel;
        }
        private async Task<RefreshToken> GenerateRefreshToken(string UserId, string TokenId)
        {
            var refreshToken = new RefreshToken();
            var randomNumber = new byte[32];

            using (var randomNumerGenerator = RandomNumberGenerator.Create())
            {
                randomNumerGenerator.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
                refreshToken.ExpiryDateTimeUtc = DateTime.UtcNow.AddMonths(6);
                refreshToken.CreatedDateTimeUtc = DateTime.UtcNow;
                refreshToken.UserId = UserId;
                refreshToken.JwtId = TokenId;
            }

            await databaseContext.AddAsync(refreshToken);
            await databaseContext.SaveChangesAsync();

            return refreshToken;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenModel refreshToken)
        {
            var user = GetUserFromAccessToken(refreshToken.Token);

            if (user != null && ValidateRefreshToken(user, refreshToken.RefreshToken))
            {
                await signInManager.RefreshSignInAsync(user);

                RefreshTokenModel refreshTokenModel = await GenerateAccessToken(user);

                return Ok(new
                {
                    success = true,
                    token = refreshTokenModel.Token,
                    refreshToken = refreshTokenModel.RefreshToken,
                    expiration = refreshTokenModel.Expiration,
                    userId = user.Id
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("user")]
        public async Task<ProfilKompanije> GetUser([FromBody] RefreshTokenModel refreshToken)
        {
            var user = GetUserFromAccessToken(refreshToken.Token);
            if (user != null)
            {
                    await signInManager.RefreshSignInAsync(user);
                    var profile = databaseContext.ProfilKompanije.SingleOrDefault(x => x.UserId == user.Id);
                    return profile;
            }
            return null;
        }

        private bool ValidateRefreshToken(IdentityUser user, string refreshToken)
        {
            RefreshToken rtUser = databaseContext.RefreshToken.Where(rt => rt.Token == refreshToken)
                .OrderByDescending(rt => rt.ExpiryDateTimeUtc)
                .FirstOrDefault();

            if (rtUser != null && rtUser.UserId == user.Id && rtUser.ExpiryDateTimeUtc > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        private IdentityUser GetUserFromAccessToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:ValidAudience"],
                ValidIssuer = _configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                RequireExpirationTime = false,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                var userName = principal.FindFirst(ClaimTypes.Name)?.Value;

                var userInfo = databaseContext.Users.FirstOrDefault(u => u.UserName == userName);

                return userInfo;
            }

            return null;
        }

        /*[HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Registeration([FromBody] Register registerModel)
        {
            var userExists = await userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new IdentityUser()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.User));
            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.Company))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Company));

            if (await roleManager.RoleExistsAsync(ApplicationUserRoles.User))
            {
                await userManager.AddToRoleAsync(user, ApplicationUserRoles.User);
            }

            /*if (!string.IsNullOrEmpty(registerModel.Role) && registerModel.Role == ApplicationUserRoles.Admin)
            {
                await userManager.AddToRoleAsync(user, ApplicationUserRoles.Admin);
            }
            else
            {
                await userManager.AddToRoleAsync(user, ApplicationUserRoles.User);
            }*/
            /*var profile = new ProfilAplikanta()
            {
                Ime = registerModel.Ime,
                Prezime = registerModel.Prezime,
                KontaktTelefon = registerModel.KontaktTelefon,
                DatumRodjenja = registerModel.DatumRodjenja,
                Drzava = registerModel.Drzava,
                Grad = registerModel.Grad,
                Adresa = registerModel.Adresa,
                SlikaProfila = registerModel.SlikaProfila,
                UserId = user.Id
            };
            await databaseContext.AddAsync(profile);
            await databaseContext.SaveChangesAsync();

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }*/

        [HttpPost]
        [AllowAnonymous]
        [Route("registerAdmin")]
        public async Task<IActionResult> AdminRegisteration([FromForm] RegisterAdmin registerModel)
        {
            var userExists = await userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new IdentityUser()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.User));
            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.Company))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Company));


            if (await roleManager.RoleExistsAsync(ApplicationUserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, ApplicationUserRoles.Admin);
            }
            if (registerModel.ImageFile == null) 
            {
                registerModel.SlikaProfila = "default.png";
            }
            else
                registerModel.SlikaProfila = await SaveImage(registerModel.ImageFile);

            var profile = new ProfilAdministratora()
            {
                Ime = registerModel.Ime,
                Prezime = registerModel.Prezime,
                SlikaProfila = registerModel.SlikaProfila,
                UserId = user.Id
            };

            databaseContext.Add(profile);
            await databaseContext.SaveChangesAsync();

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("registerCompany")]
        public async Task<IActionResult> CompanyRegisteration([FromForm] RegisterCompany registerModel)
        {
            var userExists = await userManager.FindByNameAsync(registerModel.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new IdentityUser()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Username
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.User));
            if (!await roleManager.RoleExistsAsync(ApplicationUserRoles.Company))
                await roleManager.CreateAsync(new IdentityRole(ApplicationUserRoles.Company));

            if (await roleManager.RoleExistsAsync(ApplicationUserRoles.Company))
            {
                await userManager.AddToRoleAsync(user, ApplicationUserRoles.Company);
            }

            if (registerModel.ImageFile == null)
            {
                registerModel.Logo = "unnamed.png";
            }
            else
                registerModel.Logo = await SaveImage(registerModel.ImageFile);

            var profile = new ProfilKompanije()
            {
                Naziv = registerModel.Naziv,
                Misija = registerModel.Misija,
                Logo = registerModel.Logo,
                KontaktTelefon = registerModel.KontaktTelefon,
                KontaktEmail = registerModel.Email,
                WebSiteURL = registerModel.WebSiteURL,
                UserId = user.Id
            };

            await databaseContext.AddAsync(profile);
            await databaseContext.SaveChangesAsync();


            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            var response = new Response
            {
                Message = "Logout success!",
                Status = "Success"
            };

            return Ok(response);
        }

        /*[HttpPost]
        [Route("updateUserProfile")]
        public async Task<IActionResult> UpdateUserProfile(ProfilAplikanta profileModel)
        {
            try
            {
                if (profileModel == null)
                {
                    return BadRequest();
                }

                var currentUserId = User.Claims.ToList().FirstOrDefault(x => x.Type == "id").Value;

                var profile = new ProfilAplikanta
                {
                    Ime = profileModel.Ime,
                    Prezime = profileModel.Prezime,
                    KontaktTelefon = profileModel.KontaktTelefon,
                    Drzava = profileModel.Drzava,
                    Grad = profileModel.Grad,
                    Adresa = profileModel.Adresa,
                    SlikaProfila = profileModel.SlikaProfila
                };

                bool result = await accountRepository.UpdateProfileAsync(profile, currentUserId);

                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }*/
        [HttpPost]
        [Route("updateAdminProfile")]
        public async Task<IActionResult> UpdateAdminProfile(ProfilAdministratora profileModel)
        {
            try
            {
                if (profileModel == null)
                {
                    return BadRequest();
                }


                var currentUserId = User.Claims.ToList().FirstOrDefault(x => x.Type == "id").Value;

                var profile = new ProfilAdministratora
                {
                    Ime = profileModel.Ime,
                    Prezime = profileModel.Prezime,
                    SlikaProfila = profileModel.SlikaProfila
                };

                bool result = await accountRepository.UpdateAdminProfileAsync(profile, currentUserId);

                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("updateCompanyProfile")]
        public async Task<IActionResult> UpdateCompanyProfile(ProfilKompanije profileModel)
        {
            try
            {
                if (profileModel == null)
                {
                    return BadRequest();
                }


                var currentUserId = User.Claims.ToList().FirstOrDefault(x => x.Type == "id").Value;

                var profile = new ProfilKompanije
                {
                    Naziv = profileModel.Naziv,
                    Misija = profileModel.Misija,
                    KontaktTelefon = profileModel.KontaktTelefon,
                    KontaktEmail = profileModel.KontaktEmail,
                    Logo = profileModel.Logo,
                    WebSiteURL = profileModel.WebSiteURL
                };

                bool result = await accountRepository.UpdateCompanyProfileAsync(profile, currentUserId);

                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("AdminProfile")]
        public async Task<IEnumerable<ProfilAdministratora>> GetAdminProfile()
        {
            return await databaseContext.ProfilAdministratora
                .Select(x => new ProfilAdministratora()
                {
                    Ime = x.Ime,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.SlikaProfila)
                }).ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("CompanyProfile")]
        public async Task<IEnumerable<ProfilKompanije>> GetCompanyProfile()
        {
            return await databaseContext.ProfilKompanije
                .Select(x => new ProfilKompanije()
                {
                    Naziv = x.Naziv,
                    Misija = x.Misija,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Logo),
                    KontaktEmail = x.KontaktEmail,
                    KontaktTelefon = x.KontaktTelefon,
                    WebSiteURL = x.WebSiteURL
                }).ToListAsync();
        }

        // return databaseContext.ProfilAdministratora;

        /* [HttpGet]
         [Route("Profile")]
         public async Task<IActionResult> GetProfile()
         {

             var currentUserId = User.Claims.ToList().FirstOrDefault(x => x.Type == "id").Value;

             var userProfile = (await databaseContext.GetUserByIds.FromSqlInterpolated($"Exec GetProfile @userId = {currentUserId}").ToListAsync()).FirstOrDefault();

             return Ok(userProfile);
         }*/
    }
}

