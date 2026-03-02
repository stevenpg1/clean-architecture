using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentailOfficesList;
using CleanTeeth.Application.Utilities;
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
        public Task<AppointmentsListDTO> Handle(GetAppointmentsListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
