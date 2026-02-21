using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public static class MapperExtensions
    {
        public static DentalOfficeDetailDTO ToDto(this DentalOffice dentalOffice)
        {
            return new DentalOfficeDetailDTO {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
        }
    }
}
