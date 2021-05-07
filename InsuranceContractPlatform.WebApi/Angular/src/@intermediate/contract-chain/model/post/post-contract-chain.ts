import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Contractor } from "src/@intermediate/contractor/model/get/get-create-contractor";

export class PostContractChainResponse 
{
    ContractChain: string;
}

export class PostContractChainRequest 
{
    Contractors: Contractor[];
}

export class ContractChainForm extends FormGroup 
{
  constructor() {
    super({
      FirstContractor: new FormControl([],Validators.required),
      SecondContractor: new FormControl([],Validators.required),
    });
  }
}