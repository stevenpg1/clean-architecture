using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeeth.Domain.Entities;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    public static class MapperExtensions
    {
        public static DentistsListDTO ToDto(this IEnumerable<Dentist> dentists)
        {
            return new DentistsListDTO
            {
                Dentists = dentists.Select(d => new DentistDetailDTO
                {
                    //Id = d.Id,
                    //Name = d.Name
                }).ToList()
            };
        }
    }
}
