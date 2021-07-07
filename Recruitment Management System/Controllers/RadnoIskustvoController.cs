using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMSLibrary.Models;
using RMSLibrary.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruitment_Management_System.Controllers
{
    [Authorize(Roles = ApplicationUserRoles.User)]
    [Authorize(Roles = ApplicationUserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class RadnoIskustvoController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RadnoIskustvoController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: api/<RadnoIskustvoController>
        [HttpGet]
        public IEnumerable<RadnoIskustvo> Get()
        {
            return _applicationDbContext.RadnoIskustvo;
        }

        // GET api/<RadnoIskustvoController>/5
        [HttpGet("{id}")]
        public RadnoIskustvo Get(int id)
        {
            return _applicationDbContext.RadnoIskustvo.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<RadnoIskustvoController>
        [HttpPost]
        public void Post([FromBody] RadnoIskustvo value)
        {
            _applicationDbContext.RadnoIskustvo.Add(value);
            _applicationDbContext.SaveChanges();
        }

        // PUT api/<RadnoIskustvoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RadnoIskustvo value)
        {
            var item = _applicationDbContext.RadnoIskustvo.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.NazivKompanije = value.NazivKompanije;
                item.Adresa = value.Adresa;
                item.RadnaPozicija = value.RadnaPozicija;
                item.DatumPocetka = value.DatumPocetka;
                item.DatumPocetka = value.DatumZavrsetka;
                _applicationDbContext.RadnoIskustvo.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<RadnoIskustvoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.RadnoIskustvo.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _applicationDbContext.RadnoIskustvo.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
