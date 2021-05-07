import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Contractor } from 'src/@intermediate/contractor/model/get/get-create-contractor';

export class PostContractResponse 
{
  ContractExists: boolean;
  public ContractRemoved : boolean;
}

export class PostContractRequest 
{
  public Contractors: Contractor[];
}

  export class ContractsForm extends FormGroup 
  {
    constructor() {
      super({
        FirstContractor: new FormControl([],Validators.required),
        SecondContractor: new FormControl([],Validators.required),
      });
    }
  }
  


export class InsuranceContractDetails 
{
    Id: number;
    InsuranceContractId: number;
    ContractorId: number;
}