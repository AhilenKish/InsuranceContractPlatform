import { Component, OnInit } from '@angular/core';
import { ContractChainForm, PostContractChainRequest } from 'src/@intermediate/contract-chain/model/post/post-contract-chain';
import { GetContractRequest, GetContractResponse } from 'src/@intermediate/contract/model/get/get-contract';
import { Contractor } from 'src/@intermediate/contractor/model/get/get-create-contractor';
import { ContractChainService } from 'src/@services/contract-chain/contract-chain.service';

@Component({
  selector: 'app-contract-chain',
  templateUrl: './contract-chain.component.html',
  styleUrls: ['./contract-chain.component.scss']
})
export class ContractChainComponent implements OnInit 
{

  form: ContractChainForm
  model: GetContractResponse;
  controctors: Contractor[];
  controctor1: Contractor;
  controctor2: Contractor;
  firstContractorId: number;
  secondContractorId: number;
  shortestChain: string;
  showResult: boolean = false;
  panelOpenState: boolean ;
  constructor(private contractChain: ContractChainService) 
  {
    this.form = new ContractChainForm();
    this.model = new GetContractResponse();
  }

  ngOnInit()
  {
    var request = new GetContractRequest();
    this.load(request);
  }

  load(request: GetContractRequest)
  {
    this.contractChain.get(request).subscribe(response =>{
      this.model = response;
    })
  }

  save(form: ContractChainForm)
  {
    this.getContractors();
    let req = new PostContractChainRequest();
    req.Contractors = this.controctors;
    this.shortestChain = null;
    this.showResult = true;
    this.contractChain.chain(req).subscribe(response =>{
      
      if(response.ContractChain == null)
      {
        this.shortestChain = "No contract found.";
      }
      else
      {
        this.shortestChain = response.ContractChain;
      }
    });
    
  }

  getContractorID1(Id: number)
  {
    this.showResult = false;
    this.firstContractorId = Id;
  }

  getContractorID2(Id: number)
  {
    this.showResult = false;
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
