using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMSLibrary.Models;
using RMSLibrary.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruitment_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class LokacijaController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LokacijaController(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: api/<LokacijaController>
        [HttpGet]
        public IEnumerable<Lokacija> Get()
        {
            return _applicationDbContext.Lokacija;
        }

        // GET api/<LokacijaController>/5
        [HttpGet("{id}")]
        public Lokacija Get(int id)
        {
            return _applicationDbContext.Lokacija.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<LokacijaController>
        [HttpPost]
        public void Post([FromBody] Lokacija st)
        {

            _applicationDbContext.Lokacija.Add(st);
            _applicationDbContext.SaveChanges();

        }

        // PUT api/<LokacijaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lokacija lokacija)
        {
            var item = _applicationDbContext.Lokacija.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Drzava = lokacija.Drzava;
                item.Grad = lokacija.Grad;
                item.Ulica = lokacija.Ulica;
                item.ProfilKompanija = lokacija.ProfilKompanija;
                _applicationDbContext.Lokacija.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<LokacijaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.Lokacija.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _applicationDbContext.Lokacija.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
