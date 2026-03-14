using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public class GetDentalOfficesListQueryHandler : IRequestHandler<GetDentalOfficesListQuery, DentalOfficesListDTO>
    {
        private readonly IDentalOfficeRepository repository;

        public GetDentalOfficesListQueryHandler(
            IDentalOfficeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DentalOfficesListDTO> Handle(GetDentalOfficesListQuery request)
        {
            var dentalOffices = await repository.GetAll();
            return dentalOffices.ToDto();
        }
    }
}
