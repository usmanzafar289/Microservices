import { CalculationService } from '../calculation.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'calculation-detail',
  template: ` <h2>Calculation Details</h2>
    <h3>{{ errorMsg }}</h3>
    <ul *ngFor="let cal of calculations">
      <li>
        {{ cal.id }} - {{ cal.name }} -{{ cal.timespan }} - {{ cal.value }}
      </li>
    </ul>
    <h4>SUM of Value :</h4> {{ this.sum}}

    <h4>Average of Value :</h4> {{ this.average}}
    `
    ,
  styles: [],
})
export class CalculationsDetailComponent implements OnInit {
  calculations = [] as any;
  public errorMsg: any;
  sum: number = 0;
  average: number = 0;


  constructor(private _calculationService: CalculationService) {}

  ngOnInit() {

    this._calculationService.getCalculations().subscribe(
      (data) => {
        this.calculations = data;
        this.sum = data.filter(item => item.value)
                        .reduce((sum, current) => sum + current.value, 0);
       this.average = (this.sum / data.length) || 0;
       this.average = Math.trunc(this.average*100)/100;
       console.log(data); 
      },
      (error) => {
        this.errorMsg = error;
      }
    );
  }
}
