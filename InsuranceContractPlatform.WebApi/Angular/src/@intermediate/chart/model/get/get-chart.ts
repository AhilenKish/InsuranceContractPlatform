export class GetChartResponse {
  public Contractors: ContactorsChart[];
  public Relationship: ContactorsChart[];
}

export interface ContactorsChart {
  Id: number;
  Name: string;
  ContractCount: number;
  Description: string;
}

export interface InsuranceContract {
  Id: number;
  Description: string;
}

export class GetChartRequest {}
