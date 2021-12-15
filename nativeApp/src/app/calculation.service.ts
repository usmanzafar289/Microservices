import { Injectable } from "@angular/core";
import { HttpClient, HttpClientModule,HttpErrorResponse  } from "@angular/common/http";
import { ICalculation } from "./calculation";
import { Observable, throwError } from 'rxjs';

import { catchError } from 'rxjs/operators';




@Injectable()
export class CalculationService {
    response = "No data loaded, yet";
    constructor(private http: HttpClient) 
    { 
      // this.http.get('http://localhost:49155/api/APIService/example1', {responseType: 'text'}).subscribe((response: any) => {
      //   console.log(response);
      //   this.response = response;		
      // });
      
    }
    getCalculations(): Observable<ICalculation[]> {
      return this.http.get<ICalculation[]>('http://localhost:49155/api/APIService/example1').pipe(catchError(this.erroHandler));
    }
  
    erroHandler(error: HttpErrorResponse) {
      return throwError(error.message || 'server Error');
    }

  }
