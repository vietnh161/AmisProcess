import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { Page404Component } from './page404/page404.component';
import { HomeComponent } from './home/home.component';
import { TestComponent } from './test/test.component';

import { AuthGuard } from './_helpers';
import { from } from 'rxjs';
import { MainLayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'test',
    component: MainLayoutComponent
  },
  {
    path: 'home',
  // component: HomeComponent,
   loadChildren: () => import(`./home/home.module`).then(m => m.HomeModule),
  //  canActivate: [AuthGuard],
  //   data: {role: [Role.Employee]}
    //component: ListprocessComponent
  },
  // {
  //   path: 'list-process',
  //  loadChildren: () => import(`./manage-process/list-process/list-process.module`).then(m => m.ListProcessModule),
    
  // },
  {
    path: 'create-process',
   loadChildren: () => import(`./create-process/create-process.module`).then(m => m.CreateProcessModule),
    
  },
  {
    path: 'manage-process',
   loadChildren: () => import(`./manage-process/manage-process.module`).then(m => m.ManageProcessModule),
    
  },
  {
    path: 'notfound',
    component: Page404Component
  },
  {
    path: '**',
    component: Page404Component
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
