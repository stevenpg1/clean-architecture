using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail
{
    public static class MapperExtensions
    {
        public static PatientDetailDTO ToDto(this Patient patient)
        {
            return new PatientDetailDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value
            };
        }
    }
}
