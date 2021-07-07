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
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StatusController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // GET: api/<StatusController>
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _applicationDbContext.Status;
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public Status Get(int id)
        {
            return _applicationDbContext.Status.SingleOrDefault(x => x.Id == id); ;
        }

        // POST api/<StatusController>
        [HttpPost]
        public void Post([FromBody] Status value)
        {
            _applicationDbContext.Status.Add(value);
            _applicationDbContext.SaveChanges();
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Status value)
        {
            var item = _applicationDbContext.Status.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.OpisniAtribut = value.OpisniAtribut;
                _applicationDbContext.Status.Update(item);
                _applicationDbContext.SaveChanges();
            }
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.Status.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _applicationDbContext.Status.Remove(item);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
