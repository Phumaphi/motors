using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagoMotors.Core.Interface;
using LagoMotors.Data.Interface;

namespace LagoMotors.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbcontext _context;


        public UnitOfWork(AppDbcontext context)
        {
            _context = context;
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
