import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostContractChainRequest, PostContractChainResponse } from 'src/@intermediate/contract-chain/model/post/post-contract-chain';
import { GetContractRequest, GetContractResponse } from 'src/@intermediate/contract/model/get/get-contract';

@Injectable({
  providedIn: 'root'
})
export class ContractChainService {

constructor(private http: HttpClient) { }


baseUrl = 'https://localhost:5001/api/';

  get(request: GetContractRequest): Observable<GetContractResponse> {
    return this.http.get<GetContractResponse>(
      this.baseUrl + 'contracts',
      request
    );
  } 

  chain(request: PostContractChainRequest): Observable<PostContractChainResponse> {
    return this.http.post<PostContractChainResponse>(
      this.baseUrl + 'contractchain/chain',
      request
    );
  }

}
