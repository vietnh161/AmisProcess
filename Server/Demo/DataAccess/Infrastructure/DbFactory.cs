using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Infrastructure
{
    public class DbFactory : Disposable
    {
        private DemoDbContext dbContext;
        private DbContextOptions<DemoDbContext> options;

        public DemoDbContext Init()
        {
            return dbContext ?? (dbContext = new DemoDbContext(options));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
