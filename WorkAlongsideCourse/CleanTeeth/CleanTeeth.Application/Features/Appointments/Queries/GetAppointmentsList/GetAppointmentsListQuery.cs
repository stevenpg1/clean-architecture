using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQuery : AppointmentsFilterDto, IRequest<AppointmentsListDTO>
    {
    }
}
