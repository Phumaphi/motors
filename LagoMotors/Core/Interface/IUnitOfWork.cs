using System.Threading.Tasks;

namespace LagoMotors.Data.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
