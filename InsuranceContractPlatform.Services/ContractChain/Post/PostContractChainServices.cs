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

namespace InsuranceContractPlatform.Services.ContractChain.Post
{
    public class PostContractChainServices : PostContractChainRequest
    {
    }

    public class PostContractChainServicesHandler : IRequestHandler<PostContractChainServices, PostContractChainResponse>
    {
        private readonly DataContext _context;
        private List<int> list;
        public PostContractChainServicesHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<PostContractChainResponse> Handle(PostContractChainServices request, CancellationToken cancellationToken)
        {

            var response = new PostContractChainResponse();
            response.ContractChain = await GetShortestChain(request);
            return response;
        }

        private async Task<string> GetShortestChain(PostContractChainServices request)
        {
            string chain = null;


            var contractsForFirstContractor = await FindContractors(request.Contractors[0].Id);
            var contractsForSecondContractor = await FindContractors(request.Contractors[1].Id);
            
            // no contracts
            if (contractsForFirstContractor.Count == 0 || contractsForSecondContractor.Count == 0 || (request.Contractors[0].Id == request.Contractors[1].Id))
            {
                return chain;
            }
            
            var contractExsists = (from f in contractsForFirstContractor
                                   join s in contractsForSecondContractor on f equals s
                                   select f).Distinct().ToList();

            if (contractExsists.Count() > 0)
            {
                // direct link
                var contractChain = (from rec in _context.Contractors
                                     join details in _context.ContractDetails on rec.Id equals details.ContractorId
                                     where contractExsists.Contains(details.InsuranceContractId)
                                     select rec).ToList();

                if (contractChain.Count > 0)
                {
                    chain = "";
                    var listString = new List<string>();
                    foreach (Contractor c in contractChain)
                    {
                        listString.Add(c.Name);
                    }
                    chain = string.Join(" -- ", listString);
                    return chain;
                }
            }
            else
            {
                // indirect link
               
                var firstContractors = GetContractDetails(contractsForFirstContractor);
                var secondContractors = GetContractDetails(contractsForSecondContractor);
                var firstContracts = firstContractors.Select(s => s.InsuranceContractId).Distinct().ToList();
                var secondContracts = secondContractors.Where(d => d.ContractorId != request.Contractors[1].Id).Select(s => s.InsuranceContractId).Distinct().ToList();  // remove the contractor that is in lookup

                // contracts exists between both

                var s = (from r in firstContractors
                         join j in secondContractors on r equals j
                         select r).ToList();

                if (s.Count() > 0)
                {
                    // existes
                }
                else
                {
                    // find connections that connected with contracts

                    var chainList = new List<int>();

                    foreach (var si in secondContracts)
                    {
                        var x = _context.ContractDetails.Where(d => d.InsuranceContractId == si && d.ContractorId != request.Contractors[1].Id).Select(m => m).ToList(); // return all contract details 
                        if (x.Count() > 0)
                        {
                            foreach (var firstctors in x)
                            {
                                var retContracts = _context.ContractDetails.Where(s => s.ContractorId == firstctors.ContractorId).Select(f => f).ToList(); // get contacts

                                foreach (var item in retContracts)
                                {
                                    var listOfContracts = _context.ContractDetails.Where(d => d.InsuranceContractId == item.InsuranceContractId).Select(t => t).ToList();

                                    // check if the first contracters exists
                                    var v = listOfContracts.Where(v => v.ContractorId == request.Contractors[0].Id).Select(f => f).ToList();
                                    chainList.Add(item.InsuranceContractId);

                                    if (v.Count() > 0)
                                    {
                                        var c = GetContractorIds(chainList);

                                        if (!c.Contains(request.Contractors[1].Id))
                                        {
                                            c.Add(request.Contractors[1].Id);
                                        }
                                        var l = GetContractorNames(c);
                                        chain = string.Join(" -- ", l);
                                        return chain;
                                    }
                                    else
                                    {
                                        list = new List<int>();
                                        list = CheckRecursively(listOfContracts, request.Contractors);
                                        var m = GetContractorIds(list);

                                        if (!m.Contains(request.Contractors[1].Id))
                                        {
                                            m.Add(request.Contractors[1].Id);
                                        }

                                        var l = GetContractorNames(m);
                                        chain = string.Join(" -- ", l);
                                        return chain;

                                    }

                                }
                            }
                        }
                    }

                }
            }

            return chain;
        }

        

        private List<int> CheckRecursively(List<InsuranceContractDetails> contractList, List<Contractor> requestContractors)
        {
            var c = contractList.Select(s => s.InsuranceContractId).Distinct().ToList();

            foreach (var item in c)
            {
                var v = _context.ContractDetails.Where(c => c.InsuranceContractId == item).Select(s => s).ToList();
                list.Add(item);
                if (v.Where(w => w.ContractorId == requestContractors[0].Id).Count() > 0)
                {
                    return list;
                }
                else
                {
                    // find other contracts
                    var cid = v.Select(g => g.ContractorId);

                    var f = (from b in _context.ContractDetails
                             where cid.Contains(b.ContractorId) && b.InsuranceContractId != _context.ContractDetails.Where(n => n.ContractorId == requestContractors[1].Id).Select(d => d.InsuranceContractId).Distinct().FirstOrDefault()
                             select b).ToList();
                    var filter = (from u in f where !list.Contains(u.InsuranceContractId) select u).ToList();

                    return CheckRecursively(filter, requestContractors);

                }
            }

            return list;
        }


        private List<int> GetContractorIds(List<int> list)
        {
            return (from f in _context.ContractDetails where list.Contains(f.InsuranceContractId) select f.ContractorId).Distinct().ToList();
        }

        private List<string> GetContractorNames(List<int> m)
        {
            return (from rec in _context.Contractors where m.Contains(rec.Id) select rec.Name).Distinct().ToList();
        }

        private async Task<List<int>> FindContractors(int id)
        {
            return await _context.ContractDetails.Where(c => c.ContractorId == id).Select(s => s.InsuranceContractId).Distinct().ToListAsync();
        }

        private List<InsuranceContractDetails> GetContractDetails(List<int> contractsForFirstContractor)
        {
            return (from h in _context.ContractDetails where contractsForFirstContractor.Contains(h.InsuranceContractId) select h).ToList();
        }
    }


}
