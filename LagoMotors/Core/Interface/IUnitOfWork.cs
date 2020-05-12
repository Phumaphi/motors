using System.Threading.Tasks;

namespace LagoMotors.Core.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
