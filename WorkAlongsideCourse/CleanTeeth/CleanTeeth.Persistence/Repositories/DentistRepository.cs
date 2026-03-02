using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class DentistRepository : Repository<Dentist>, IDentistRepository
    {
        public DentistRepository(CleanTeethDbContext context)
            : base(context)
        {

        }
    }
}
