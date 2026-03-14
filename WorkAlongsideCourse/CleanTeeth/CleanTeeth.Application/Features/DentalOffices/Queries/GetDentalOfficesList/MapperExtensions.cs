using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public static class MapperExtensions
    {
        public static DentalOfficesListDTO ToDto(this IEnumerable<DentalOffice> dentalOffices)
        {
            return new DentalOfficesListDTO
            {
                DentalOffices = dentalOffices.Select(d => new DentalOfficeDetailDTO
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToList()
            };
        }
    }
}
