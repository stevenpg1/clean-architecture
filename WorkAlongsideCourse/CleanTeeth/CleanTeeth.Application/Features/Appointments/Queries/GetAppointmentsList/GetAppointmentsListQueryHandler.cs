using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.Apointments.Queries.GetAppointmentsList;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, AppointmentsListDTO>
    {
        private readonly IAppointmentRepository repository;

        public GetAppointmentsListQueryHandler(
            IAppointmentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<AppointmentsListDTO> Handle(GetAppointmentsListQuery request)
        {
            var appointments = await repository.GetAll();
            return appointments.ToDto();
        }
    }
}
