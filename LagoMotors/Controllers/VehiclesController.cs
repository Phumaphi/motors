using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LagoMotors.Controllers.Resources;
using LagoMotors.Core.Interface;
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
        private readonly IVehicleRepository _iVehicleRepo;
        private readonly IUnitOfWork _iUnitOfWork;


        public VehiclesController(
            IMapper mapper,
            AppDbcontext context,
            IVehicleRepository iVehicleRepo,
            IUnitOfWork iUnitOfWork)
        {
            _mapper = mapper;
            _iVehicleRepo = iVehicleRepo;
            _iUnitOfWork = iUnitOfWork;
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
            await _iUnitOfWork.CompleteAsync();
            vehicle = Task.FromResult(await _iVehicleRepo.GetVehicle(id));
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

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource);
            vehicle.LastUpdate=DateTime.Now;
            _iVehicleRepo.Add(vehicle);

            await _iUnitOfWork.CompleteAsync();


         vehicle = await _iVehicleRepo.GetVehicle(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
         
         return CreatedAtAction("AllVehicles", new { id = vehicle.Id }, result);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _iVehicleRepo.GetVehicle(id, includeRelated: false);
            if (vehicle == null)
            {
                return NotFound();
            }

            _iVehicleRepo.Remove(vehicle);
            await _iUnitOfWork.CompleteAsync();

            return Ok(id);
        }

    }
}
