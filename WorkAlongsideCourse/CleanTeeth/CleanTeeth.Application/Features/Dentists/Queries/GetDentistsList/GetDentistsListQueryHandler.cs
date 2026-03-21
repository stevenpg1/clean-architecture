using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList
{
    public class GetDentistsListQueryHandler : IRequestHandler<GetDentistsListQuery, PaginatedDTO<DentistDetailDTO>>
    {
        private readonly IDentistRepository repository;

        public GetDentistsListQueryHandler(
            IDentistRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PaginatedDTO<DentistDetailDTO>> Handle(GetDentistsListQuery request)
        {
            var dentists = await repository.GetFiltered(request);
            var recordCount = await repository.GetRecordCount();
            return dentists.ToDto(recordCount);
        }
    }
}
