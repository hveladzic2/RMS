using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSLibrary.Models.DBModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Popraviti sve za oglasId
/// </summary>
namespace Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplikacijaController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AplikacijaController(ApplicationDbContext applicationDbContext, IWebHostEnvironment hostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            this._hostEnvironment = hostEnvironment;
        }
        // GET: api/<OglasiController>
        [HttpGet("{id}")]
        public IEnumerable<Aplikacija> Get(int id)
        {
            var result= _applicationDbContext.Aplikacija
                .Select(x => new Aplikacija()
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    KontaktTelefon = x.KontaktTelefon,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.SlikaProfila),
                    CVSrc = String.Format("{0}://{1}{2}/Files/{3}", Request.Scheme, Request.Host, Request.PathBase, x.CVdokument),
                    CVdokument = x.CVdokument,
                    Drzava = x.Drzava,
                    Grad = x.Grad,
                    Adresa = x.Adresa,
                    Spol = x.Spol,
                    DatumRodjenja = x.DatumRodjenja,
                    MotivacionoPismo = x.MotivacionoPismo,
                    ProfilKompanijeId = x.ProfilKompanijeId,
                    oglasId = x.oglasId

                }).ToList();
            return result.FindAll(x => x.oglasId == id);
        }


        /*// GET api/<OglasiController>/5
        [HttpGet("{id}")]
        public Aplikacija Get(int id)
        {

            return _applicationDbContext.Aplikacija.SingleOrDefault(x => x.ProfilKompanijeId == id);
        }*/

        // POST api/<OglasiController>
        [HttpPost]
        public void Post([FromForm] Aplikacija value)
        {
            if (value.ImageFile == null)
            {
                value.SlikaProfila = "image_plac.png";
            }
            else
                value.SlikaProfila = SaveImage(value.ImageFile);

            if (value.CVFile != null)
                value.CVdokument = SaveFile(value.CVFile);

            _applicationDbContext.Aplikacija.Add(value);
            _applicationDbContext.SaveChanges();
        }

        // PUT api/<OglasiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Aplikacija value)
        {
            var item = _applicationDbContext.Aplikacija.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Ime = value.Ime != null ? value.Ime : item.Ime;
                item.Prezime = value.Prezime != null ? value.Prezime : item.Prezime;
                item.Email = value.Email != null ? value.Email : item.Email;
                item.KontaktTelefon = value.KontaktTelefon != null ? value.KontaktTelefon : item.KontaktTelefon;
                item.SlikaProfila = value.SlikaProfila != null ? value.SlikaProfila : item.SlikaProfila;
                item.CVdokument = value.CVdokument!=null ? value.CVdokument : item.CVdokument;
                item.MotivacionoPismo = value.MotivacionoPismo != null ? value.MotivacionoPismo : item.MotivacionoPismo;
                item.Drzava = value.Drzava != null ? value.Drzava : item.Drzava;
                item.Grad = value.Grad != null ? value.Grad : item.Grad;
                item.Spol = value.Spol != null ? value.Spol : item.Spol;
                item.DatumRodjenja = value.DatumRodjenja != null ? value.DatumRodjenja : item.DatumRodjenja;
                item.ProfilKompanijeId = value.ProfilKompanijeId;
                item.oglasId = value.oglasId;
                _applicationDbContext.Aplikacija.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<OglasiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.Aplikacija.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _applicationDbContext.Aplikacija.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
        [NonAction]
        public string SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName));
            imageName = imageName + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
            {
                 imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        [NonAction]
        public string SaveFile(IFormFile file)
        {
            string fileName = new String(Path.GetFileNameWithoutExtension(file.FileName));
            fileName = fileName + Path.GetExtension(file.FileName);
            /* var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", fileName);
             using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
             {
                 file.CopyToAsync(fileStream);
             }*/
            string folderPath = "Files/";
            folderPath += file.FileName;

            string serverFolder = Path.Combine(_hostEnvironment.ContentRootPath, folderPath);

               file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return fileName;
        }
    }
}
