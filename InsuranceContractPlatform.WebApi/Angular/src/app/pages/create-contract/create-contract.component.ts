import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { GetContractRequest, GetContractResponse } from 'src/@intermediate/contract/model/get/get-contract';
import { ContractsForm, PostContractRequest } from 'src/@intermediate/contract/model/post/post-contract';
import { Contractor } from 'src/@intermediate/contractor/model/get/get-create-contractor';
import { ContractService } from 'src/@services/contract/contract.service';

@Component({
  selector: 'app-create-contract',
  templateUrl: './create-contract.component.html',
  styleUrls: ['./create-contract.component.scss']
})
export class CreateContractComponent implements OnInit {

  form: ContractsForm
  model: GetContractResponse;
  controctors: Contractor[];
  controctor1: Contractor;
  controctor2: Contractor;
  firstContractorId: number;
  secondContractorId: number;
  errorMessage: string;
  sucessMessage: string;
  panelOpenState: boolean;
  //updateChart: boolean;
  @Output()
  updateChartOnCreate = new EventEmitter();

  constructor(private contractService: ContractService) 
  {
    this.form = new ContractsForm();
    this.model = new GetContractResponse();
  }

  ngOnInit()
  {
    let request = new GetContractRequest();
    this.load(request);
  }

  load(request: GetContractRequest)
  {
    this.contractService.get(request).subscribe(response =>{
      this.model = response;
    })
  }

  save(form: ContractsForm)
  {
    this.getContractors();
    let req = new PostContractRequest();
    req.Contractors = this.controctors;
    this.errorMessage = null;
    this.sucessMessage = null;
    if(req.Contractors[0].Id == req.Contractors[1].Id)
    {
      this.errorMessage = "You can not select same contractors to create contract.";
      return;
    }
    this.contractService.create(req).subscribe(response =>{
      this.sucessMessage = "Sucessfully Created.";
      this.updateChartOnCreate.emit("true");
    },
    error=>{
      this.errorMessage = error.error;
    }
    );
    
  }

  remove(form: ContractsForm) 
  {
    this.getContractors();
    let req = new PostContractRequest();
    req.Contractors = this.controctors;
    this.errorMessage = null;
    this.sucessMessage = null;
    if(req.Contractors[0].Id == req.Contractors[1].Id)
    {
      this.errorMessage = "You can not select same contractors to remove contract.";
      return;
    }
    this.contractService.remove(req).subscribe((response) => {
      this.sucessMessage = "Sucessfully Removed."
    });
  }

  getContractorID1(Id: number)
  {
    this.errorMessage = null;
    this.sucessMessage = null;
    this.firstContractorId = Id;
  }

  getContractorID2(Id: number)
  {
    this.errorMessage = null;
    this.sucessMessage = null;
    this.secondContractorId = Id;
  }

  getContractors()
  {
    let con1 = this.model.Contractors.filter(f=>f.Id == this.firstContractorId);
    let con2 = this.model.Contractors.filter(f=>f.Id == this.secondContractorId);
    
    this.controctor1 = new Contractor();
    this.controctor2 = new Contractor();

    this.controctor1.Id = con1[0].Id;
    this.controctor1.Name = con1[0].Name;
    this.controctor1.Address = con1[0].Address;
    this.controctor1.ContractorTypeId = con1[0].ContractorTypeId;
    this.controctor1.PhoneNumber = con1[0].PhoneNumber;

    this.controctor2.Id = con2[0].Id;
    this.controctor2.Name = con2[0].Name;
    this.controctor2.Address = con2[0].Address;
    this.controctor2.ContractorTypeId = con2[0].ContractorTypeId;
    this.controctor2.PhoneNumber = con2[0].PhoneNumber;
    
    this.controctors = [];

    this.controctors.push(this.controctor1);
    this.controctors.push(this.controctor2);
  }

}
