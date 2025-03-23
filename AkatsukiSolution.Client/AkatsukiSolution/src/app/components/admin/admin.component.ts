import { Component } from '@angular/core';
import * as XLSX from 'xlsx';
import { TotalProjectTime } from 'src/app/models/totalProjectTime';
import { User } from 'src/app/models/user';
import { WorkingDayItemVm } from 'src/app/models/workingDayItemVm';
import { EmployeeService } from 'src/app/services/employee/employee.service';
import { WorkingDayService } from 'src/app/services/workingDay/working-day.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent {
  constructor(
    private workingDayService: WorkingDayService,
    private employeeService: EmployeeService
  ) {}
  headers = [
    { key: 'id', value: 'Ид' },
    { key: 'date', value: 'Датум' },
    { key: 'employeeFullName', value: 'Име и презиме' },
    { key: 'hours', value: 'број сати' },
    { key: 'projectName', value: 'Пројекат' },
    { key: 'taskDescription', value: 'Задатак' },
  ];

  employeeData: WorkingDayItemVm[] = [];

  selectedEmployee = '';

  employees: User[] = [];

  originalEmployeeData: WorkingDayItemVm[] = [];

  totalProjectData!: TotalProjectTime[];
  ngOnInit() {
    this.headers.shift();
    this.getAllEmployees();
    this.getAllWorkingDays();
  }

  getAllWorkingDays() {
    this.workingDayService.getAllWorkingDays().subscribe((data) => {
      this.employeeData = data;
      this.originalEmployeeData = [...this.employeeData];
      this.formProjectData(data);
    });
  }

  onSelectionChange(event: any) {
    const selectedEmployee = event.target.value;

    if(selectedEmployee === 'Сви запослени'){
      this.getAllWorkingDays()
    }
    const filteredData = this.originalEmployeeData.filter(
      (ed) => ed.employeeFullName === selectedEmployee
    );

    this.employeeData = filteredData;
    this.formProjectData(filteredData)
  }

  getAllEmployees() {
    this.employeeService
      .getAllEmployees()
      .subscribe((data) => {
        this.employees = data
        this.employees.unshift({id: -1, firstName: 'Сви', lastName: 'запослени', title: '', role: null, manager: null})
      });
  }

  exportToExcel(): void {
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(this.employeeData);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Employees');

    XLSX.writeFile(wb, `izvestaj_${new Date().toDateString()}.xlsx`);
  }

  formProjectData(data: WorkingDayItemVm[]) {
    const groupedData = data.reduce((acc, curr) => {
      if (acc[curr.projectName]) {
        acc[curr.projectName] += curr.hours;
      } else {
        acc[curr.projectName] = curr.hours;
      }
      return acc;
    }, {} as { [key: string]: number });

    this.totalProjectData = Object.keys(groupedData).map((projectName) => ({
      projectName,
      totalHours: groupedData[projectName],
    }));
  }
}
