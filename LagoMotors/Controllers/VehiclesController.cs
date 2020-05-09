using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LagoMotors.Controllers.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LagoMotors.Data;
using LagoMotors.Models;

namespace LagoMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public VehiclesController(IMapper mapper, AppDbcontext context)
        {
            _mapper = mapper;
            _context = context;
        }
        private readonly AppDbcontext _context;



        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> AllVehicles()
        {
            var vehicles = await _context.Vehicles.Include(f=>f.Features).ToListAsync();

            var results = _mapper.Map<List<Vehicle>, List<VehicleResource>>(vehicles);
            return Ok(results);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.Include(f=>f.Features).SingleOrDefaultAsync(v=>v.Id==id);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(vehicle);


            return Ok(vehicleResource);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskVehicle(int id, VehicleResource vehicleResource)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate= DateTime.Now;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _context.Models.FindAsync(vehicleResource.ModelId);

            // validate model Id 
            if (model == null )
            {
                ModelState.AddModelError("ModelId", "Invalid modelId.");
                return BadRequest(ModelState);
            }
            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate=DateTime.Now;
         _context.Vehicles.Add(vehicle);
         await _context.SaveChangesAsync();
         var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
         
         return CreatedAtAction("AllVehicles", new { id = vehicle.Id }, result);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
