import { Component } from '@angular/core';
import { EmployeeWorkingDayItem } from 'src/app/models/employeeWorkingDayItem';
import { WorkingDayService } from 'src/app/services/workingDay/working-day.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent {
  constructor(private workingDayService: WorkingDayService){}
  headers = [
    { key: 'id', value: 'Ид' },
    { key: 'fullName', value: 'Име и презиме' },
    { key: 'date', value: 'Датум' },
    { key: 'task', value: 'Задатак' },
    { key: 'description', value: 'Опис' },
    { key: 'workingHours', value: 'Број сати' },
  ];

  employeeData: EmployeeWorkingDayItem[] = [
    {
      id: 1,
      fullName: 'Nikola Dj',
      date: new Date().toDateString(),
      task: 'test',
      description: 'test',
      workingHours: 7,
    },
    {
      id: 2,
      fullName: 'Marko M',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      workingHours: 6,
    },
    {
      id: 3,
      fullName: 'Pavle L',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      workingHours: 6.5,
    },
  ];
  ngOnInit() {
    this.headers.shift();
    this.workingDayService.getWorkingDay(1).subscribe(data => console.log(data));
    
  }
}
