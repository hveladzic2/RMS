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
    public class ObrazovanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ObrazovanjeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: api/<ObrazovanjeController>
        [HttpGet]
        public IEnumerable<Obrazovanje> Get()
        {
            return _applicationDbContext.Obrazovanje;
        }

        // GET api/<ObrazovanjeController>/5
        [HttpGet("{id}")]
        public Obrazovanje Get(int id)
        {
            return _applicationDbContext.Obrazovanje.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<ObrazovanjeController>
        [HttpPost]
        public void Post([FromBody] Obrazovanje value)
        {
            _applicationDbContext.Obrazovanje.Add(value);
            _applicationDbContext.SaveChanges();
        }

        // PUT api/<ObrazovanjeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Obrazovanje value)
        {
            var item = _applicationDbContext.Obrazovanje.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Zvanje = value.Zvanje;
                item.StepenCertifikata = value.StepenCertifikata;
                item.NazivObrazovneInstitucije = value.NazivObrazovneInstitucije;
                item.Drzava = value.Drzava;
                item.Grad = value.Grad;
                _applicationDbContext.Obrazovanje.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<ObrazovanjeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.Obrazovanje.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _applicationDbContext.Obrazovanje.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
