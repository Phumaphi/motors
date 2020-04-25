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
    [Route("")]
    [Route("Features")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly AppDbcontext _appDbcontext;

        public FeaturesController(AppDbcontext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        // GET: api/Features
        [HttpGet]
        public async Task<IEnumerable<Feature>> Features()
        {
            var featureList = await _appDbcontext.Features.ToListAsync();


            return featureList;
        }

        // GET: api/Features/5
        [Route("{id}")]
        [HttpGet("{id}")]
        public string Feature(int id)
        {
            return "value";
        }

        // POST: api/Features
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Features/5
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
