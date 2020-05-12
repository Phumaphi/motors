using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoMotors.Data.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
