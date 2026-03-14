using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistsListQueryHandler : IRequestHandler<GetDentistsListQuery, DentistsListDTO>
    {
        private readonly IDentistRepository repository;

        public GetDentistsListQueryHandler(
            IDentistRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DentistsListDTO> Handle(GetDentistsListQuery request)
        {
            var dentists = await repository.GetAll();
            return dentists.ToDto();
        }
    }
}
