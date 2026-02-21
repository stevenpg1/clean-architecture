using CleanTeeth.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.UnitsOfWork
{
    public class UnitOFWorkEFCore : IUnitOfWork
    {
        private readonly CleanTeethDbContext context;

        public UnitOFWorkEFCore(CleanTeethDbContext context)
        {
            this.context = context;
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
