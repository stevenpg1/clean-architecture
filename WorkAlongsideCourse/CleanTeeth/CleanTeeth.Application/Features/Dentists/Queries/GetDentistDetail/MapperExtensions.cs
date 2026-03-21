using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail
{
    public static class MapperExtensions
    {
        public static DentistDetailDTO ToDto(this Dentist dentist)
        {
            return new DentistDetailDTO
            {
                Id = dentist.Id,
                Name = dentist.Name,
                Email = dentist.Email.Value
            };
        }
    }
}
