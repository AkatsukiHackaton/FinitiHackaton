import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent {
  @Input() btnClass!: string;
  @Input() title!: string;

  @Output() btnClickEvent = new EventEmitter();

  btnClick(){
    this.btnClickEvent.emit();
  }

}
