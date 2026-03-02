using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentailOfficesList;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PatientsListDTO>
    {
        private readonly IPatientRepository repository;

        public GetPatientsListQueryHandler(
            IPatientRepository repository)
        {
            this.repository = repository;
        }
        public Task<PatientsListDTO> Handle(GetPatientsListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
