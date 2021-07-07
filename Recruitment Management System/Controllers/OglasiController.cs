using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMSLibrary.Models;
using RMSLibrary.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OglasiController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OglasiController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: api/<OglasiController>
        [HttpGet]
        public IEnumerable<OglasiTable> Get()
        { 
            return _applicationDbContext.OglasiTable;
        }

        [Route("Kompanije")]
        [HttpGet]
        public List<OglasiTable> GetOglasi()
        {
            var oglasiList = _applicationDbContext.OglasiTable;
            var kompanijeList = _applicationDbContext.ProfilKompanije;
            var oglasi = oglasiList.Join(
                kompanijeList,
                oglas => oglas.ProfilKompanijeId1,
                kompanija => kompanija.Id,
                (oglas, kompanija) => new OglasiTable()
                {
                    Id = oglas.Id,
                    Odjel = oglas.Odjel,
                    Pozicija = oglas.Pozicija,
                    DodatneInformacije = oglas.DodatneInformacije,
                    PocetakPrijave = oglas.PocetakPrijave,
                    DatumIsteka = oglas.DatumIsteka,
                    Naziv = kompanija.Naziv,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, kompanija.Logo),
                    ProfilKompanijeId1 = kompanija.Id
                }).ToList();
            return oglasi;
        }

        [Route("Kompanije/{id}")]
        [HttpGet]
        public List<OglasiTable> GetOglasi(int id)
        {
            var oglasiList = _applicationDbContext.OglasiTable;
            var kompanijeList = _applicationDbContext.ProfilKompanije;
            var oglasi = oglasiList.Join(
                kompanijeList,
                oglas => oglas.ProfilKompanijeId1,
                kompanija => kompanija.Id,
                (oglas, kompanija) => new OglasiTable()
                {
                    Id = oglas.Id,
                    Odjel = oglas.Odjel,
                    Pozicija = oglas.Pozicija,
                    DodatneInformacije = oglas.DodatneInformacije,
                    PocetakPrijave = oglas.PocetakPrijave,
                    DatumIsteka = oglas.DatumIsteka,
                    Naziv = kompanija.Naziv,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, kompanija.Logo),
                    ProfilKompanijeId1 = kompanija.Id
                }).ToList();
            return oglasi.FindAll(x => x.ProfilKompanijeId1 == id );
        }

        // GET api/<OglasiController>/5
        [HttpGet("{id}")]
        public OglasiTable Get(int id)
        {
            return _applicationDbContext.OglasiTable.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<OglasiController>
        [HttpPost]
        public void Post([FromBody] OglasiTable value)
        {
            var datum1 = value.DatumIsteka;
            var noviDatum1 = "";
            noviDatum1 = noviDatum1 + datum1.Substring((datum1.Length - 2), 2) + ".";
            noviDatum1 = noviDatum1 + datum1.Substring((datum1.Length - 5), 2) + ".";
            noviDatum1 = noviDatum1 + datum1.Substring((datum1.Length - 10), 4);
            value.DatumIsteka = noviDatum1;
            _applicationDbContext.OglasiTable.Add(value);
            _applicationDbContext.SaveChanges();
        }
        //variable = (condition) ? expressionTrue :  expressionFalse;

        // PUT api/<OglasiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OglasiTable value)
        {
            var datum1 = value.DatumIsteka;
            if (datum1 != null)
            {
                var noviDatum1 = "";
                noviDatum1 = noviDatum1 + datum1.Substring((datum1.Length - 2), 2) + ".";
                noviDatum1 = noviDatum1 + datum1.Substring((datum1.Length - 5), 2) + ".";
                noviDatum1 = noviDatum1 + datum1.Substring((datum1.Length - 10), 4);
                value.DatumIsteka = noviDatum1;
            }
            var item = _applicationDbContext.OglasiTable.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Pozicija = value.Pozicija!=null ? value.Pozicija : item.Pozicija;
                item.Odjel = value.Odjel!=null ? value.Odjel : item.Odjel;
                item.DodatneInformacije = value.DodatneInformacije!=null ? value.DodatneInformacije : item.DodatneInformacije;
                item.PocetakPrijave = value.PocetakPrijave!=null ? value.PocetakPrijave : item.PocetakPrijave;
                item.DatumIsteka = value.DatumIsteka!=null ? value.DatumIsteka : item.DatumIsteka;
                item.Status = value.Status!=null ? value.Status : item.Status;
                item.ProfilKompanijeId1 = value.ProfilKompanijeId1;
                _applicationDbContext.OglasiTable.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<OglasiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.OglasiTable.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                List<Aplikacija> aplikacije = _applicationDbContext.Aplikacija.ToList();
                aplikacije = aplikacije.FindAll(x => x.oglasId == id);
                foreach (Aplikacija aplikacija in aplikacije)
                {
                    var item2 = _applicationDbContext.Aplikacija.FirstOrDefault(x => x.Id == aplikacija.Id);
                    if (item2 != null)
                    {
                        _applicationDbContext.Aplikacija.Remove(item2);
                        _applicationDbContext.SaveChanges();
                    }
                }
                _applicationDbContext.OglasiTable.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
