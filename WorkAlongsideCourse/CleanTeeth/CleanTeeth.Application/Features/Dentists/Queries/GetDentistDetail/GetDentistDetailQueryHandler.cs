using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Exceptions;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail
{
    public class GetDentistDetailQueryHandler : IRequestHandler<GetDentistDetailQuery, DentistDetailDTO>
    {
        private readonly IDentistRepository repository;

        public GetDentistDetailQueryHandler(
            IDentistRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DentistDetailDTO> Handle(GetDentistDetailQuery request)
        {
            var dentist = await repository.GetById(request.Id);
            if (dentist is null)
            {
                throw new NotFoundException();
            }
            return dentist.ToDto();
        }
    }
}
