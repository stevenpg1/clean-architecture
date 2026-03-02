using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleanTeeth.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
    {
        private readonly IPatientRepository repository;

        public GetPatientDetailQueryHandler(
            IPatientRepository repository)
        {
            this.repository = repository;
        }

        public Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
