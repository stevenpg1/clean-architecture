using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    public static class MapperExtensions
    {
        public static PaginatedDTO<DentistDetailDTO> ToDto(this IEnumerable<Dentist> dentists, int recordCount)
        {
            return new PaginatedDTO<DentistDetailDTO>
            {
                Elements = dentists.Select(d => new DentistDetailDTO
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
