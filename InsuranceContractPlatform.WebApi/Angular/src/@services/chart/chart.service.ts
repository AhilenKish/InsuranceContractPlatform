import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetChartResponse } from 'src/@intermediate/chart/model/get/get-chart';
import { GetChartRequest } from 'src/@intermediate/chart/model/post/post-chart';

@Injectable({
  providedIn: 'root'
})
export class ChartService {

  constructor(private http: HttpClient) { }

  baseUrl = 'https://localhost:5001/api/';
  
    get(request: GetChartRequest): Observable<GetChartResponse> {
      return this.http.get<GetChartResponse>(
        this.baseUrl + 'chart',
        request
      );
    } 

}
