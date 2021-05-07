import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {  PostContractorRequest, PostContractorResponse} from 'src/@intermediate/contractor/model/post/post-create-contractor';

@Injectable({
  providedIn: 'root',
})
export class ContractorService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}

  create(request: PostContractorRequest): Observable<PostContractorResponse> {
    return this.http.post<PostContractorResponse>(
      this.baseUrl + 'contractors/create',
      request
    );
  }
}
