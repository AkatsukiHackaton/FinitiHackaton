import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Project } from 'src/app/models/project';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { 
  }
  url:string = environment.testUrl

  getAllEmployees(): Observable<User[]>{
    return this.http.get<User[]>(this.url + 'Users/employees')
  }
}
