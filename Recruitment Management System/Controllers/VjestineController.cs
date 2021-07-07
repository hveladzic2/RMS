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
    public class VjestineController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public VjestineController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: api/<VjestineController>
        [HttpGet]
        public IEnumerable<Vjestine> Get()
        {
            return _applicationDbContext.Vjestine;
        }

        // GET api/<VjestineController>/5
        [HttpGet("{id}")]
        public Vjestine Get(int id)
        {
            return _applicationDbContext.Vjestine.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<VjestineController>
        [HttpPost]
        public void Post([FromBody] Vjestine value)
        {
            _applicationDbContext.Vjestine.Add(value);
            _applicationDbContext.SaveChanges();
        }

        // PUT api/<VjestineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vjestine value)
        {
            var item = _applicationDbContext.Vjestine.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Vjestina = value.Vjestina;
                item.NivoPoznavanja = value.NivoPoznavanja;
                _applicationDbContext.Vjestine.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<VjestineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.Vjestine.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _applicationDbContext.Vjestine.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
