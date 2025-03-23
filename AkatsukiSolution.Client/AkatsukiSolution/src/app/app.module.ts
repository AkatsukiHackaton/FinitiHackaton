import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestService } from './services/test/test.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ButtonComponent } from './components/button/button.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { AdminComponent } from './components/admin/admin.component';
import { HeaderComponent } from './components/header/header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TableComponent } from './components/table/table.component';
import { GraphComponent } from './components/graph/graph.component';

@NgModule({
  declarations: [
    AppComponent,
    ButtonComponent,
    UserFormComponent,
    AdminComponent,
    HeaderComponent,
    TableComponent,
    GraphComponent
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, RouterModule,  ReactiveFormsModule, FormsModule],
  providers: [TestService],
  bootstrap: [AppComponent],
})
export class AppModule {}
