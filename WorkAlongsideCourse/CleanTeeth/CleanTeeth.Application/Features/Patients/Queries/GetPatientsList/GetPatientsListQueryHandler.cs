using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleanTeeth.Application.Features.Patients.Queries.GetPatientDetail;
using CleanTeeth.Application.Utilities;
using CleanTeeth.Application.Utilities.Common;
using CleanTeeth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PaginatedDTO<PatientDetailDTO>>
    {
        private readonly IPatientRepository repository;

        public GetPatientsListQueryHandler(
            IPatientRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PaginatedDTO<PatientDetailDTO>> Handle(GetPatientsListQuery request)
        {
			var patients = await repository.GetFiltered(request);
            var recordCount = await repository.GetRecordCount();
            return patients.ToDto(recordCount);
		}
    }
}
