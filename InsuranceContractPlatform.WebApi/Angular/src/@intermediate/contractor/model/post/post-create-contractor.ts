import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Contractor } from '../get/get-create-contractor';

export class PostContractorRequest {

  public Controctor: Contractor;
}
export class PostContractorResponse 
{
  ContractorExists: boolean;
  Contractors: Contractor[];
}




export class ContractorForm extends FormGroup {
  constructor() {
    super({
      Name: new FormControl('',Validators.required),
      Address: new FormControl('',Validators.required),
      PhoneNumber: new FormControl('',Validators.required),
      ContractorTypeId: new FormControl(1),
      FirstContractor: new FormControl([],Validators.required),
      SecondContractor: new FormControl([],Validators.required),
    });
  }
}

