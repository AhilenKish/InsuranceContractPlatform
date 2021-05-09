using InsuranceContractPlatform.DataServices.Data;
using InsuranceContractPlatform.DataServices.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceContractPlatform.Services.Contracts.Post
{
    public class PostContractServices : PostContractRequest
    {
    }

    public class PostContractServicesHandler : IRequestHandler<PostContractServices, PostContractResponse>
    {
        private readonly DataContext _context;
        // this is used for graph 
        private int radious = 10;


        public PostContractServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<PostContractResponse> Handle(PostContractServices request, CancellationToken cancellationToken)
        {
            var response = new PostContractResponse();

            if (!await ContractExists(request.Contractors) && request.IsRemoved)
            {
                response.ContractExists = false;
                response.ContractRemoved = false;
                return response;
            }
            else if (await ContractExists(request.Contractors) && request.IsRemoved)
            {

                //remove
                var contractId1 = await _context.ContractDetails.Where(f => f.ContractorId == request.Contractors[0].Id).Select(s => s.InsuranceContractId).FirstOrDefaultAsync();
                var cd = await _context.ContractDetails.Where(w => w.InsuranceContractId == contractId1).Select(s => s).ToListAsync();
                var c = _context.Contracts.Where(w => w.Id == contractId1).Select(s => s).FirstOrDefault();

                _context.ContractDetails.RemoveRange(cd);
                _context.Contracts.Remove(c);
                await _context.SaveChangesAsync();

                response.ContractExists = false;
                response.ContractRemoved = true;
                return response;
            }
            else
            {
                response.ContractRemoved = false;
                if (await ContractExists(request.Contractors) && !request.IsRemoved)
                {
                    response.ContractExists = true;
                    return response;
                }

                var contract = new InsuranceContract
                {
                    Description = "{ " +  request.Contractors[0].Name + " -- "  + request.Contractors[1].Name + " }"
                };

                _context.Contracts.Add(contract);
                await _context.SaveChangesAsync();

                foreach (var ic in request.Contractors)
                {
                    var contractDetails = new InsuranceContractDetails
                    {
                        InsuranceContractId = contract.Id,
                        ContractorId = ic.Id
                    };
                    _context.ContractDetails.Add(contractDetails);
                    await _context.SaveChangesAsync();
                }
            }
            return response;
        }

        private async Task<bool> ContractExists(List<Contractor> insuranceContracts)
        {
            bool exists = false;
            var contractorId_1 = insuranceContracts[0].Id;
            var contractorId_2 = insuranceContracts[1].Id;
            var contractId1 = await _context.ContractDetails.Where(f => f.ContractorId == contractorId_1).Select(s => s.InsuranceContractId).Distinct().ToListAsync();
            //var contractId2 = await _context.ContractDetails.Where(f => f.ContractorId == contractorId_2).Select(s => s.InsuranceContractId).Distinct().ToListAsync();

            var t = (from g in _context.ContractDetails
                    where contractId1.Contains(g.InsuranceContractId) && g.ContractorId == contractorId_2
                    select g);

            if(t.Count() > 0)
            {
                exists = true;
            }

            return exists;
        }

    }
}
