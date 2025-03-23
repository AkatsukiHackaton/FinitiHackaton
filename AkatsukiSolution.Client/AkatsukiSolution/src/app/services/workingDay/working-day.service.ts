import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { WorkingDay } from 'src/app/models/workingDay';

@Injectable({
  providedIn: 'root'
})
export class WorkingDayService {

  constructor(private http: HttpClient) { 
  }
  url:string = environment.testUrl

  getWorkingDay(employeeId: number): Observable<WorkingDay>{
    return this.http.get<WorkingDay>(this.url + 'WorkingDays/get?userId=' + employeeId)
  }

  addWorkingDay(workingDay: WorkingDay): Observable<number>{
    return this.http.post<number>(this.url + 'WorkingDays/add', workingDay)
  }
}
