using InsuranceContractPlatform.DataServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Chart.Get
{
    public class GetChartResponse
    {
        public List<ContactorsChart> Contractors { get;  set; }
        public List<int> Contracts { get;  set; }
        public List<ContactorsChart> Relationship { get;  set; }
    }
}
