import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { CalculationService } from "./calculation.service";
import { CalculationsDetailComponent } from './calculations/calculation-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    CalculationsDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    
  ],
  providers: [CalculationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
