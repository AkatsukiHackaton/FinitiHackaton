import { ChangeDetectorRef, Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Project } from 'src/app/models/project';
import { TotalProjectTime } from 'src/app/models/totalProjectTime';
import { WorkingDay } from 'src/app/models/workingDay';
import { WorkingDayItemVm } from 'src/app/models/workingDayItemVm';
import { ProjectService } from 'src/app/services/project/project.service';
import { WorkingDayService } from 'src/app/services/workingDay/working-day.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent {
  employeeForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private workingDayService: WorkingDayService,
    private cdr: ChangeDetectorRef,
    private projectService: ProjectService
  ) {
    this.employeeForm = this.fb.group({
      formItems: this.fb.array([this.createFormItem()]),
    });
  }

  selectedProjectId: number | null = null;

  workingDay!: WorkingDay;

  projects: Project[] = [];

  totalProjectData!: TotalProjectTime[];

  headers = [
    { key: 'id', value: 'Ид' },
    { key: 'date', value: 'Датум' },
    { key: 'employeeFullName', value: 'Име и презиме' },
    { key: 'hours', value: 'број сати' },
    { key: 'projectName', value: 'Пројекат' },
    { key: 'taskDescription', value: 'Задатак' },
  ];

  employeeData: WorkingDayItemVm[] = [];

  ngOnInit() {
    this.headers.shift();
    this.getProjects();
    this.getWorkingDays();
  }

  getWorkingDays() {
    this.workingDayService
      .getWorkingDay(5)
      .subscribe((data: WorkingDayItemVm[]) => {
        this.employeeData = data.map((ed) => ({
          ...ed,
          date: ed.date.toLocaleString().slice(0, 10),
        }));
        this.formProjectData(data);
        this.cdr.detectChanges();
      });
  }

  getProjects() {
    this.projectService
      .getProjects()
      .subscribe((data) => (this.projects = data));
  }

  createFormItem(): FormGroup {
    return this.fb.group({
      date: ['', Validators.required],
      taskDescription: ['', Validators.required],
      projectId: [''],
      hours: [
        0,
        [Validators.required, Validators.min(0.1), Validators.max(10)],
      ],
    });
  }

  get formItems(): FormArray {
    return this.employeeForm.get('formItems') as FormArray;
  }

  formProjectData(employeeData: WorkingDayItemVm[]) {
    const groupedData = employeeData.reduce((acc, curr) => {
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
    this.totalProjectData = [...this.totalProjectData];
    this.cdr.detectChanges();
  }

  mapWorkingDay() {
    const workingDay: WorkingDay = this.formItems.value[0];
    const projectId = +workingDay.projectId;
    const date = new Date(workingDay.date);
    this.workingDay = workingDay;
    this.workingDay.projectId = projectId;
    this.workingDay.date = date;
    this.workingDay.id = 0;
    this.workingDay.employeeId = 5;
  }

  addFormItem(): void {
    this.formItems.push(this.createFormItem());
  }

  deleteFormItem(index: number) {
    this.formItems.removeAt(index);
  }

  onSubmit(): void {
    console.log(this.formItems.value);
    this.mapWorkingDay();
    this.workingDayService.addWorkingDay(this.workingDay).subscribe((data) => {
      this.getWorkingDays();
    });
    this.formItems.reset();
    this.cdr.detectChanges();
  }
}
