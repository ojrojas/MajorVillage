import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeModule } from './home/home.module';

const routes: Routes = [
  {
    path:'login',
    loadChildren: ()=> import('./login/login.module').then(module=> module.LoginModule)
  },
  {
    path:'home',
    loadChildren: ()=> import('./home/home.module').then(module => module.HomeModule)
  },
  {
    path:'**',
    redirectTo:'home',
    pathMatch:'full'
  },
  {
    path:'',
    redirectTo:'home',
    pathMatch:'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
