import { Contractor } from "src/@intermediate/contractor/model/get/get-create-contractor";

export class GetChartResponse 
{
    public ContactorsChart: ContactorsChart[];
}

export class ContactorsChart 
{
    public id: number;
    public name: string;
    public contractId: number;
}