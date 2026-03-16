using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Apointments.Queries.GetAppointmentDetail
{
    public static class MapperExtensions
    {
        public static AppointmentDetailDTO ToDto(this Appointment appointment)
        {
            return new AppointmentDetailDTO
            {
                
            };
        }
    }
}
