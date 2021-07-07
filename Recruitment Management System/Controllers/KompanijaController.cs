using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSLibrary.Models.DBModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompanijaController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IWebHostEnvironment _hostEnvironment;

        public KompanijaController(ApplicationDbContext applicationDbContext, IWebHostEnvironment hostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            this._hostEnvironment = hostEnvironment;
        }
        // GET: api/<OglasiController>
        [HttpGet]
        public IEnumerable<ProfilKompanije> Get()
        {
            return _applicationDbContext.ProfilKompanije
                .Select(x => new ProfilKompanije()
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Misija = x.Misija,
                    KontaktEmail = x.KontaktEmail,
                    KontaktTelefon = x.KontaktTelefon,
                    WebSiteURL = x.WebSiteURL,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Logo)
                }).ToList();
        }
        [HttpGet("{id}")]
        public ProfilKompanije Get(int id)
        {
            var x= _applicationDbContext.ProfilKompanije.SingleOrDefault(x => x.Id == id);
            x.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Logo);
            return x;
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] ProfilKompanije value)
        {

            if (value.ImageFile == null)
            {
                value.Logo = value.Logo;
            }
            else
                value.Logo = SaveImage(value.ImageFile);

            var item = _applicationDbContext.ProfilKompanije.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Naziv = value.Naziv != null ? value.Naziv : item.Naziv;
                item.Misija = value.Misija != null ? value.Misija : item.Misija;
                item.Logo = value.Logo != null ? value.Logo : item.Logo;
                item.KontaktEmail = value.KontaktEmail != null ? value.KontaktEmail : item.KontaktEmail;
                item.KontaktTelefon = value.KontaktTelefon != null ? value.KontaktTelefon : item.KontaktTelefon;
                item.WebSiteURL = value.WebSiteURL != null ? value.WebSiteURL : item.WebSiteURL;
                _applicationDbContext.ProfilKompanije.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.ProfilKompanije.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                List<OglasiTable> oglasi = _applicationDbContext.OglasiTable.ToList();
                oglasi = oglasi.FindAll(x => x.ProfilKompanijeId1 == id);
                foreach (OglasiTable oglas in oglasi)
                {
                    var item1 = _applicationDbContext.OglasiTable.FirstOrDefault(x => x.Id == oglas.Id);
                    if (item1 != null)
                    {
                        List<Aplikacija> aplikacije = _applicationDbContext.Aplikacija.ToList();
                        aplikacije = aplikacije.FindAll(x => x.oglasId == oglas.Id);
                        foreach (Aplikacija aplikacija in aplikacije)
                        {
                            var item2 = _applicationDbContext.Aplikacija.FirstOrDefault(x => x.Id == aplikacija.Id);
                            if (item2 != null)
                            {
                                _applicationDbContext.Aplikacija.Remove(item2);
                                _applicationDbContext.SaveChanges();
                            }
                        }

                        _applicationDbContext.OglasiTable.Remove(item1);
                        _applicationDbContext.SaveChanges();
                    }
                }
                _applicationDbContext.ProfilKompanije.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
        [NonAction]
        public string SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                 imageFile.CopyTo(fileStream);
            }
            return imageName;
        }
    }
}
