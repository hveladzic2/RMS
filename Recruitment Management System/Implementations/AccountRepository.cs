using Recruitment_Management_System.Interfaces;
using Recruitment_Management_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMSLibrary.Models.DBModel;

namespace Recruitment_Management_System.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext databaseContext;

        public AccountRepository(ApplicationDbContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /*public async Task<bool> UpdateProfileAsync(ProfilAplikanta profile, string currentUserId)
        {
            try
            {
                var profileInfo = databaseContext.ProfilAplikanta.FirstOrDefault(x => x.UserId == currentUserId);

                if (profileInfo != null)
                {
                    profile.Id = profileInfo.Id;
                    profile.UserId = !string.IsNullOrEmpty(profile.UserId) ? profile.UserId : profileInfo.UserId;
                    profile.Ime = !string.IsNullOrEmpty(profile.Ime) ? profile.Ime : profileInfo.Ime;
                    profile.Prezime = !string.IsNullOrEmpty(profile.Prezime) ? profile.Prezime : profileInfo.Prezime;
                    profile.KontaktTelefon = !string.IsNullOrEmpty(profile.KontaktTelefon) ? profile.KontaktTelefon : profileInfo.KontaktTelefon;
                    profile.Drzava = !string.IsNullOrEmpty(profile.Drzava) ? profile.Drzava : profileInfo.Drzava;
                    profile.Grad = !string.IsNullOrEmpty(profile.Grad) ? profile.Grad : profileInfo.Grad;
                    profile.Adresa = !string.IsNullOrEmpty(profile.Adresa) ? profile.Adresa : profileInfo.Adresa;
                    profile.SlikaProfila = !string.IsNullOrEmpty(profile.SlikaProfila) ? profile.SlikaProfila : profileInfo.SlikaProfila;
                    profile.DatumRodjenja = !(profile.DatumRodjenja == null)? profile.DatumRodjenja : profileInfo.DatumRodjenja;

                    databaseContext.Entry(profileInfo).CurrentValues.SetValues(profile);


                    await databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }*/

        public async Task<bool> UpdateAdminProfileAsync(ProfilAdministratora profile, string currentUserId)
        {
            try
            {
                var profileInfo = databaseContext.ProfilAdministratora.FirstOrDefault(x => x.UserId == currentUserId);

                if (profileInfo != null)
                {
                    profile.Id = profileInfo.Id;
                    profile.UserId = !string.IsNullOrEmpty(profile.UserId) ? profile.UserId : profileInfo.UserId;
                    profile.Ime = !string.IsNullOrEmpty(profile.Ime) ? profile.Ime : profileInfo.Ime;
                    profile.Prezime = !string.IsNullOrEmpty(profile.Prezime) ? profile.Prezime : profileInfo.Prezime;


                    databaseContext.Entry(profileInfo).CurrentValues.SetValues(profile);


                    await databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateCompanyProfileAsync(ProfilKompanije profile, string currentUserId)
        {
            try
            {
                var profileInfo = databaseContext.ProfilKompanije.FirstOrDefault(x => x.UserId == currentUserId);

                if (profileInfo != null)
                {
                    profile.Id = profileInfo.Id;
                    profile.UserId = !string.IsNullOrEmpty(profile.UserId) ? profile.UserId : profileInfo.UserId;
                    profile.Naziv = !string.IsNullOrEmpty(profile.Naziv) ? profile.Naziv : profileInfo.Naziv;
                    profile.Misija = !string.IsNullOrEmpty(profile.Misija) ? profile.Misija : profileInfo.Misija;
                    profile.KontaktTelefon = !string.IsNullOrEmpty(profile.KontaktTelefon) ? profile.KontaktTelefon : profileInfo.KontaktTelefon;
                    profile.KontaktEmail = !string.IsNullOrEmpty(profile.KontaktEmail) ? profile.KontaktEmail : profileInfo.KontaktEmail;
                    profile.Logo = !string.IsNullOrEmpty(profile.Logo) ? profile.Logo : profileInfo.Logo;
                    profile.WebSiteURL = !string.IsNullOrEmpty(profile.WebSiteURL) ? profile.WebSiteURL : profileInfo.WebSiteURL;


                    databaseContext.Entry(profileInfo).CurrentValues.SetValues(profile);


                    await databaseContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}