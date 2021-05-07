import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractChainComponent } from './contract-chain.component';

describe('ContractChainComponent', () => {
  let component: ContractChainComponent;
  let fixture: ComponentFixture<ContractChainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContractChainComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContractChainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
