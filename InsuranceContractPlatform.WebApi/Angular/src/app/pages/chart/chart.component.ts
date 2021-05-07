import { Component, OnInit } from '@angular/core';
import { GetChartRequest } from 'src/@intermediate/chart/model/post/post-chart';
import { ChartService } from 'src/@services/chart/chart.service';


@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {

  constructor(private chartService : ChartService) { }

  ngOnInit() 
  {
     this.load(new GetChartRequest());
  }

  load(request: GetChartRequest)
  {

      this.chartService.get(request).subscribe(response => {
        console.log(response);
        
      })
  }

  showChart()
  {
    this.ngOnInit();
  }

}
