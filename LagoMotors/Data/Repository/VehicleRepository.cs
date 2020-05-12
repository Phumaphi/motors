using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoMotors.Controllers.Resources;
using LagoMotors.Data.Interface;
using LagoMotors.Models;
using Microsoft.EntityFrameworkCore;

namespace LagoMotors.Data.Repository
{
    public class VehicleRepository: IVehicleRepository
    {
        private readonly AppDbcontext _context;

        public VehicleRepository(AppDbcontext context)
        {
            _context = context;
        }
        
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated=true)
        {
            if (!includeRelated)
                return await _context.Vehicles.FindAsync(id);

            return await _context.Vehicles
                .Include(f => f.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _context.Vehicles
                .Include(f => f.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Make).ToListAsync();
        }



        public void Add(Vehicle vehicle)
        {
            _context.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            _context.Remove(vehicle);
        }

       
    }

}
