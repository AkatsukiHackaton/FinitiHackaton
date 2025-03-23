import { Component } from '@angular/core';
import { EmployeeWorkingDayItem } from 'src/app/models/employeeWorkingDayItem';
import { TotalProjectTime } from 'src/app/models/totalProjectTime';
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
    { key: 'project', value: 'Пројекат' },
    { key: 'workingHours', value: 'Број сати' },
  ];

  employeeData: EmployeeWorkingDayItem[] = [
    {
      id: 1,
      fullName: 'Nikola Dj',
      date: new Date().toDateString(),
      task: 'test',
      description: 'test',
      project: 'Zlatni standard',
      workingHours: 7,
    },
    {
      id: 2,
      fullName: 'Marko M',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'Medigroup',
      workingHours: 6,
    },
    {
      id: 3,
      fullName: 'Pavle L',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'TipTimes',
      workingHours: 6.5,
    },
    {
      id: 4,
      fullName: 'Pavle L',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'Zlatni standard',
      workingHours: 6.5,
    },
    {
      id: 5,
      fullName: 'Pavle L',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'Zlatni standard',
      workingHours: 6.5,
    },
    {
      id: 6,
      fullName: 'Pavle L',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'Zlatni standard',
      workingHours: 6.5,
    },
    {
      id: 6,
      fullName: 'Ilija Jakic',
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'Mobilna aplikacija',
      workingHours: 25,
    },
  ];

  totalProjectData!: TotalProjectTime[]
  ngOnInit() {
    this.headers.shift();
    this.workingDayService.getWorkingDay(2).subscribe(data => console.log(data));
    this.formProjectData()
  }

  formProjectData(){
    const groupedData = this.employeeData.reduce((acc, curr) => {
      if (acc[curr.project]) {
        acc[curr.project] += curr.workingHours;
      } else {
        acc[curr.project] = curr.workingHours;
      }
      return acc;
    }, {} as { [key: string]: number });

    this.totalProjectData = Object.keys(groupedData).map(projectName => ({
      projectName,
      totalHours: groupedData[projectName]
    }));
  }
}
