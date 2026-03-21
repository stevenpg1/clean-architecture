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
                Appointments = appointments.Select(a => new AppointmentDetailDTO
                {
                    Id = a.Id,
                    StartDate = a.TimeInterval.Start,
                    EndDate = a.TimeInterval.End,
                    DentalOffice = a.DentalOffice!.Name,
                    Dentist = a.Dentist!.Name,
                    Patient = a.Patient!.Name,
                    Status = a.Status.ToString()
                }).ToList()
            };
        }
    }
}
