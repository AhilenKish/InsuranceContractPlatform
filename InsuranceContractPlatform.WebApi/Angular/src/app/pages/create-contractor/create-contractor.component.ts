import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ContractorForm,PostContractorRequest, PostContractorResponse } from 'src/@intermediate/contractor/model/post/post-create-contractor';
import { ContractorService } from 'src/@services/contractor/contractor.service';
import { ContractChainComponent } from '../contract-chain/contract-chain.component';
import { CreateContractComponent } from '../create-contract/create-contract.component';

@Component({
  selector: 'app-create-contractor',
  templateUrl: './create-contractor.component.html',
  styleUrls: ['./create-contractor.component.scss'],
})
export class CreateContractorComponent implements OnInit 
{
  form: ContractorForm;
  model: PostContractorResponse;
  errorMessage: string;
  sucessMessage: string;
  panelOpenState: boolean;

  @ViewChild("contract") contract: CreateContractComponent;
  @ViewChild("chain") chain: ContractChainComponent;

  constructor(private contractorService: ContractorService) 
  {
    this.form = new ContractorForm();
    this.model = new PostContractorResponse();
  }

  ngOnInit() 
  { 
      this.form.valueChanges.subscribe(c=>{
        this.errorMessage = null;
        this.sucessMessage = null;
      })
  }

  save(form: ContractorForm) 
  {
    let req = new PostContractorRequest();
    req = form.value;
    this.errorMessage = null;
    this.sucessMessage = null;
    if(this.form.controls["Name"].value == "" || this.form.controls["Address"].value == "" || this.form.controls["PhoneNumber"].value == "")
    {
      return;
    }
    this.contractorService.create(req).subscribe((response) => {
      this.contract.ngOnInit();
      this.chain.ngOnInit();
      this.sucessMessage = "Sucessfully Added.";
    },error=>{
      this.errorMessage = error.error;
    });
  }

 

  

}
