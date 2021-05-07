import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateContractorComponent } from './pages/create-contractor/create-contractor.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { CreateContractComponent } from './pages/create-contract/create-contract.component';
import { ContractChainComponent } from './pages/contract-chain/contract-chain.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatGridListModule} from '@angular/material/grid-list';
import { ChartComponent } from './pages/chart/chart.component';


@NgModule({
  declarations: [AppComponent, CreateContractorComponent, CreateContractComponent, ContractChainComponent,ChartComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatButtonModule,
    ReactiveFormsModule,
    CommonModule,
    MatSelectModule,
    MatAutocompleteModule,
    NgbModule,
    MatExpansionModule,
    MatGridListModule
    
  ],
  exports: [MatFormFieldModule, MatInputModule, MatRippleModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
