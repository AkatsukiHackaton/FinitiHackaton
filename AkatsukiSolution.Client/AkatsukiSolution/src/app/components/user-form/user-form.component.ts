import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Project } from 'src/app/models/project';
import { TotalProjectTime } from 'src/app/models/totalProjectTime';
import { WorkingDay } from 'src/app/models/workingDay';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent {
  employeeForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.employeeForm = this.fb.group({
      formItems: this.fb.array([this.createFormItem()]),
    });
  }

  selectedProjectId: number | null = null;

  projects: Project[] = [
    { id: 1, name: 'TipTimes', managerId: 4 },
    { id: 2, name: 'Zlatni standard', managerId: 5 },
    { id: 3, name: 'MediGroup', managerId: 3 },
  ];

  totalProjectData!: TotalProjectTime[]

  headers = [
    { key: 'id', value: 'Ид' },
    { key: 'date', value: 'Датум' },
    { key: 'task', value: 'Задатак' },
    { key: 'description', value: 'Опис' },
    { key: 'project', value: 'Пројекат' },
    { key: 'workingHours', value: 'Број сати' },
  ];

  employeeData = [
    {
      id: 1,
      date: new Date().toDateString(),
      task: 'test',
      description: 'test',
      project: 'Zlatni standard',
      workingHours: 7,
    },
    {
      id: 2,
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'Medigroup',
      workingHours: 6,
    },
    {
      id: 3,
      date: new Date().toDateString(),
      task: 'test1',
      description: 'test1',
      project: 'TipTimes',
      workingHours: 6.5,
    },
  ];

  ngOnInit() {
    this.headers.shift();
    this.formProjectData()
  }

  createFormItem(): FormGroup {
    return this.fb.group({
      date: ['', Validators.required],
      task: ['', Validators.required],
      description: ['', Validators.required],
      project: [''],
      workingHours: [
        0,
        [Validators.required, Validators.min(0.1), Validators.max(10)],
      ],
    });
  }

  get formItems(): FormArray {
    return this.employeeForm.get('formItems') as FormArray;
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

  mapWorkingDay() {
    const workingDay: WorkingDay = this.formItems.value[0];
    console.log(workingDay);
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
    this.formItems.reset()
  }
}
