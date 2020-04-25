using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LagoMotors.Controllers.Resources;
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
        private readonly IMapper _mapper;

        public FeaturesController(AppDbcontext appDbcontext, IMapper mapper)
        {
            _appDbcontext = appDbcontext;
            _mapper = mapper;
        }
        // GET: api/Features
        [HttpGet]
        public async Task<IEnumerable<FeatureResource>> Features()
        {
            var featureList = await _appDbcontext.Features.ToListAsync();
            var feature= _mapper.Map<List<FeatureResource>>(featureList);

            return feature;
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
