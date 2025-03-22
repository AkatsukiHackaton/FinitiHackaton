import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AdminComponent } from './components/admin/admin.component';
import { UserFormComponent } from './components/user-form/user-form.component';

const routes: Routes = [{
  path: '', component: AppComponent
},
{
  path: 'administracija', component: AdminComponent
},
{
  path: 'zaposleni', component: UserFormComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
