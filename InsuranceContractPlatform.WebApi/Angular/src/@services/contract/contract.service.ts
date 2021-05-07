import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetContractRequest, GetContractResponse } from 'src/@intermediate/contract/model/get/get-contract';
import { PostContractRequest, PostContractResponse } from 'src/@intermediate/contract/model/post/post-contract';


@Injectable({
  providedIn: 'root'
})
export class ContractService {
  

constructor(private http: HttpClient) { }

baseUrl = 'https://localhost:5001/api/';

  get(request: GetContractRequest): Observable<GetContractResponse> {
    return this.http.get<GetContractResponse>(
      this.baseUrl + 'contracts',
      request
    );
  } 

  create(request: PostContractRequest): Observable<PostContractResponse> {
    return this.http.post<PostContractResponse>(
      this.baseUrl + 'contracts/create',
      request
    );
  }

  remove(request: PostContractRequest) : Observable<PostContractResponse> {
    return this.http.post<PostContractResponse>(
      this.baseUrl + 'contracts/remove',
      request
    );
  }
}
