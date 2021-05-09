import { Component, Input, OnInit } from '@angular/core';
import { ChartService } from 'src/@services/chart/chart.service';
import { ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import * as Chart from 'chart.js';
import { map } from 'rxjs/operators';
import {
  GetChartRequest,
  GetChartResponse,
} from 'src/@intermediate/chart/model/get/get-chart';
import { PostChartRequest } from 'src/@intermediate/chart/model/post/post-chart';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss'],
})
export class ChartComponent implements OnInit {
  lineChartLegend = true;
  lineChartPlugins = [];
  lineChartType: any = 'line';
  model: GetChartResponse;
  lineChartData: ChartDataSets[];
  lineChartLabels: Label[];
  lineChartOptions: any;
  footerMessage: string;

  @Input()
  UpdateChart: boolean;

  lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: '#6495ed',
    },
  ];

  constructor(private chartService: ChartService) {
    this.model = new GetChartResponse();
  }

  ngOnInit() {
    this.load(new GetChartRequest());
  }

  load(request: GetChartRequest) {
    const footer = (tooltipItem, data) => {
      let Id = -1;
      this.model.Contractors.forEach(function (contractor, index) {
        if (tooltipItem.index == index) {
          Id = contractor.Id;
        }
      });

      return this.model.Relationship.filter((f) => f.Id == Id).map(
        (m) => m.Name
      );
    };

    this.chartService.get(request).subscribe((response) => {
      this.model = response;
      this.lineChartData = [
        {
          data: this.model.Contractors.map((m) => m.ContractCount),
          label: 'Contracts',
        },
      ];

      this.lineChartLabels = this.model.Contractors.map((m) => m.Name);
    });

    this.lineChartOptions = {
      responsive: true,
      tooltips: {
        mode: 'label',
        callbacks: {
          label: footer,
        },
      },
    };
  }

  refershGraph(type: string) {
    this.lineChartType = type;
    this.ngOnInit();
  }
}
