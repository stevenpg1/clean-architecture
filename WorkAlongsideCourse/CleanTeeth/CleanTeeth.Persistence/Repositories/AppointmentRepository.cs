using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly CleanTeethDbContext context;

        public AppointmentRepository(CleanTeethDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<bool> OverlapExists(Guid dentistId, DateTime start, DateTime end)
        {
            return await context.Appointments
                .Where(x => x.DentistId == dentistId && x.Status == AppointmentStatus.Scheduled
                && start < x.TimeInterval.End && end > x.TimeInterval.Start
                ).AnyAsync();
        }

        // the new overrides the default one define in IRepository
        new public async Task<Appointment?> GetById(Guid id)
        {
            return await context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Dentist)
                .Include(x => x.DentalOffice)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDto filter)
        {
            var queryable = context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Dentist)
                .Include(x => x.DentalOffice)
                .AsQueryable();

            if (filter.DentalOfficeId.HasValue)
            {
                queryable = queryable.Where(x => x.DentalOfficeId == filter.DentalOfficeId.Value);
            }

            if (filter.DentistId.HasValue)
            {
                queryable = queryable.Where(x => x.DentistId == filter.DentistId.Value);
            }

            if (filter.PatientId.HasValue)
            {
                queryable = queryable.Where(x => x.PatientId == filter.PatientId.Value);
            }   

            return await queryable.Where(x => x.TimeInterval.Start >= filter.StartDate 
                && x.TimeInterval.End <= filter.EndDate)
                .OrderBy(x => x.TimeInterval.Start)
                .ToListAsync();
        }
    }
}
