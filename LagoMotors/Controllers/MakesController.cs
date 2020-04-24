using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoMotors.Data;
using LagoMotors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LagoMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly AppDbcontext _appDbcontext;

        public MakesController(AppDbcontext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        // GET: api/Makes
        [HttpGet]
        public async Task<IEnumerable<Make>> Makes()
        {
            var makelist = await _appDbcontext.Makes.Include(c => c.Models).ToListAsync();

            return makelist;
        }

        // GET: api/Makes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Makes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Makes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
