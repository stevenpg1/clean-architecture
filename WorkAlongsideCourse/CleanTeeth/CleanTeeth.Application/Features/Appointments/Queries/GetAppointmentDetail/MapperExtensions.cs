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
                Id = appointment.Id,
                StartDate = appointment.TimeInterval.Start,
                EndDate = appointment.TimeInterval.End,
                DentalOffice = appointment.DentalOffice!.Name,
                Dentist = appointment.Dentist!.Name,
                Patient = appointment.Patient!.Name,
                Status = appointment.Status.ToString()
            };
        }
    }
}
