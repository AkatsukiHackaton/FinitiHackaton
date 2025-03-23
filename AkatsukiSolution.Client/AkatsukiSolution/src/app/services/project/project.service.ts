import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Project } from 'src/app/models/project';
import { WorkingDay } from 'src/app/models/workingDay';
import { WorkingDayItemVm } from 'src/app/models/workingDayItemVm';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http: HttpClient) { 
  }
  url:string = environment.testUrl

  getProjects(): Observable<Project[]>{
    return this.http.get<Project[]>(this.url + 'Projects/list')
  }
}
