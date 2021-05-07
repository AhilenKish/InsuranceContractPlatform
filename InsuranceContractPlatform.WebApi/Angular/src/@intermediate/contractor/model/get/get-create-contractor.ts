
export class GetContractorResponse 
{
  ContractorExists: boolean;
  Contractors: Contractor[];
}

export class Contractor 
{
  public Id: number;
  public Name: string;
  public Address: string;
  public PhoneNumber: string;
  public ContractorTypeId: number;
}