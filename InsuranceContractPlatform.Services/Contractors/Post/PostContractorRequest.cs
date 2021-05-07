using InsuranceContractPlatform.DataServices.Entities;
using InsuranceContractPlatform.Services.Contractors.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contractors.Post
{
    public class PostContractorRequest : IRequest<PostContractorResponse>
    {
        public Contractor Contractor { get; set; }
    }
}
