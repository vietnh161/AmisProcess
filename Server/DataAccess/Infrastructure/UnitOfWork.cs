using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AmisProcessDbContext _context;
        public UnitOfWork(AmisProcessDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
