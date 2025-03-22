import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestService } from './services/test/test.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ButtonComponent } from './components/button/button.component';
import { UserFormComponent } from './components/user-form/user-form.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
    ButtonComponent,
    UserFormComponent,
  ],
  providers: [TestService],
  bootstrap: [AppComponent],
})
export class AppModule {}
