import { Contractor } from "src/@intermediate/contractor/model/get/get-create-contractor";


export class GetContractResponse 
{
  ContractorExists: boolean;
  Contractors: Contractor[];
}

export class GetContractRequest 
{

}