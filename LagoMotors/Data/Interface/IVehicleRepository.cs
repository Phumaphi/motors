using System.Collections.Generic;
using System.Threading.Tasks;
using LagoMotors.Models;

namespace LagoMotors.Core.Interface
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated=true);
        Task<List<Vehicle>> GetVehicles();
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}
