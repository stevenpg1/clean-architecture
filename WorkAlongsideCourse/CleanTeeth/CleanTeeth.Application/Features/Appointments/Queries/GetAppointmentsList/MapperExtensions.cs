using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Apointments.Queries.GetAppointmentsList
{
    public static class MapperExtensions
    {
        public static AppointmentsListDTO ToDto(this IEnumerable<Appointment> appointments)
        {
            return new AppointmentsListDTO
            {
                Appointments = appointments.Select(d => new AppointmentDetailDTO
                {
                    //Id = d.Id,
                    //Name = d.Name
                }).ToList()
            };
        }
    }
}
