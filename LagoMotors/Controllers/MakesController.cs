using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LagoMotors.Controllers.Resources;
using LagoMotors.Data;
using LagoMotors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LagoMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly AppDbcontext _appDbcontext;
        private readonly IMapper _mapper;

        public MakesController(AppDbcontext appDbcontext, IMapper mapper)
        {
            _appDbcontext = appDbcontext;
            _mapper = mapper;
        }
        // GET: api/Makes
        [HttpGet]
        public async Task<IEnumerable<MakeResource>>Makes()
        {

            var makelist = await _appDbcontext.Makes
                .Include(c => c.Models).ToListAsync();
            List<MakeResource> makeResources = _mapper.Map<List<MakeResource>>(makelist);

            return makeResources;
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
