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
            return await _context.Vehicles.ToListAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
         


            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate=DateTime.Now;
         _context.Vehicles.Add(vehicle);
         await _context.SaveChangesAsync();
         var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
         
         return CreatedAtAction("AllVehicles", new { id = vehicle.Id }, result);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
