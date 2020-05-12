using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoMotors.Controllers.Resources;
using LagoMotors.Models;

namespace LagoMotors.Data.Interface
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
        Task<List<Vehicle>> GetVehicles();
    }
}
