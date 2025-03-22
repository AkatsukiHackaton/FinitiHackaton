import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent<T extends Record<string, any>> {
  constructor(){
  }
  @Input() headers: {key:string, value: string}[] = []
  @Input() data: T[] = []
}
