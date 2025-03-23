import { Component } from '@angular/core';

export class panelItem  {
  id!: number;
  panel!: string;
  active!: boolean;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {

  items:panelItem[] = [
    { id: 1,panel: 'FINITI izveštaji', active: false },
    {id:2,panel: 'Administracija', active: false },
    {id:3, panel: 'Zaposleni', active: false },
  ];
  toggle(index: number) {
    this.items.forEach((item: panelItem, i:number) => i === index ? item.active = true : item.active = false);
    this.items[index].active = true;
  }
}
