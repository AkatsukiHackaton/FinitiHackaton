import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

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

  createFormItem(): FormGroup {
    return this.fb.group({
      date: ['', Validators.required],
      task: ['', Validators.required],
      description: ['', Validators.required],
      workingHours: [
        0,
        [Validators.required, Validators.min(0.1), Validators.max(10)],
      ],
    });
  }

  get formItems(): FormArray {
    return this.employeeForm.get('formItems') as FormArray;
  }

  addFormItem(): void {
    this.formItems.push(this.createFormItem());
  }

  deleteFormItem(index: number) {
    this.formItems.removeAt(index);
  }

  onSubmit(): void {
    console.log(this.formItems.value);
  }
}
