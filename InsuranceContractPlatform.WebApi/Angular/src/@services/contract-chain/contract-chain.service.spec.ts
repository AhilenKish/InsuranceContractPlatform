/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ContractChainService } from './contract-chain.service';

describe('Service: ContractChain', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ContractChainService]
    });
  });

  it('should ...', inject([ContractChainService], (service: ContractChainService) => {
    expect(service).toBeTruthy();
  }));
});
