import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'cloudnativeApp';
  response = "No data loaded, yet";
  // constructor(private http: HttpClient) 
  // { 
  //   this.http.get('http://localhost:49155/api/APIService/example1', {responseType: 'text'}).subscribe((response: any) => {
  //     console.log(response);
	//   this.response = response;		
	// });
}
