using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(CleanTeethDbContext context)
            : base(context)
        {

        }
    }
}
