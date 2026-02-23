using CleanTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Application.Features.DentalOffices.Queries.GetDentailOfficesList
{
    public class DentalOfficesListDTO
    {
        public List<DentalOfficeDetailDTO> DentalOffices { get; set; }
    }
}
