import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetChartRequest, GetChartResponse } from 'src/@intermediate/chart/model/get/get-chart';
import { PostChartRequest, PostChartResponse } from 'src/@intermediate/chart/model/post/post-chart';


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

    post(request: PostChartRequest): Observable<PostChartResponse> {
      return this.http.post<PostChartResponse>(
        this.baseUrl + 'chart',
        request
      );
    }

}
