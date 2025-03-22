import { Component } from '@angular/core';
import { TestService } from './services/test/test.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(private testService: TestService) {}
  response!: string | null;
  ngOnInit() {
  }
}
