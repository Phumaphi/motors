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
using LagoMotors.Data.Interface;
using LagoMotors.Models;

namespace LagoMotors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbcontext _context;
        private readonly IVehicleRepository _iVehicleRepo;


        public VehiclesController(IMapper mapper, AppDbcontext context, IVehicleRepository iVehicleRepo)
        {
            _mapper = mapper;
            _context = context;
            _iVehicleRepo = iVehicleRepo;
        }
      

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> AllVehicles()
        {
            var vehicles = await _iVehicleRepo.GetVehicles();

            var results = _mapper.Map<List<Vehicle>, List<VehicleResource>>(vehicles);
            return Ok(results);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _iVehicleRepo.GetVehicle(id);

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
        public async Task<IActionResult> UpdateTaskVehicle(int id, SaveVehicleResource saveVehicleResource)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = _iVehicleRepo.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource, vehicle.Result);
            vehicle.Result.LastUpdate= DateTime.Now;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle.Result);

            return Ok(result);
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource saveVehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _context.Models.FindAsync(saveVehicleResource.ModelId);

            // validate model Id 
            if (model == null )
            {
                ModelState.AddModelError("ModelId", "Invalid modelId.");
                return BadRequest(ModelState);
            }
            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource);
            vehicle.LastUpdate=DateTime.Now;
         _context.Vehicles.Add(vehicle);
         await _context.SaveChangesAsync();


         vehicle = await _iVehicleRepo.GetVehicle(vehicle.Id);

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
