using System.Collections.Generic;
using System.Threading.Tasks;
using LagoMotors.Models;

namespace LagoMotors.Data.Repository
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
        Task<List<Vehicle>> GetVehicle();
    }
}