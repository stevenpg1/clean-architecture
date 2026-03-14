using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientsList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly CleanTeethDbContext context;

        public PatientRepository(CleanTeethDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO filter)
        {
            return await context
                        .Patients
                        .OrderBy(x => x.Name)
                        .Paginate(filter.Page, filter.RecordsPerPage)
                        .ToListAsync();
        }
    }
}
