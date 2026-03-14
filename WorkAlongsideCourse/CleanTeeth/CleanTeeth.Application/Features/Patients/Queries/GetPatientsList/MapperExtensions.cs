
using CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;
using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    public static class MapperExtensions
    {
        public static PaginatedDTO<PatientDetailDTO> ToDto(this IEnumerable<Patient> patients, int recordCount)
        {
            return new PaginatedDTO<PatientDetailDTO>
            {
                Elements = patients.Select(d => new PatientDetailDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    Email = d.Email.Value
                }).ToList(),
                RecordCount = recordCount
            };
        }
    }
}
