import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { Page404Component } from './page404/page404.component';
import { TestComponent } from './test/test.component';

import { AuthGuard } from './_helpers';
import { from } from 'rxjs';
import { MainLayoutComponent } from './layout/layout.component';
import { RunProcessComponent } from './run-process/run-process.component'

const routes: Routes = [
  {
    path: '',
    redirectTo: 'run-process',
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
  // {
  //   path: 'home',
  // // component: HomeComponent,
  //  loadChildren: () => import(`./home/home.module`).then(m => m.HomeModule),
  // //  canActivate: [AuthGuard],
  // //   data: {role: [Role.Employee]}
  //   //component: ListprocessComponent
  // },
  // {
  //   path: 'list-process',
  //  loadChildren: () => import(`./manage-process/list-process/list-process.module`).then(m => m.ListProcessModule),
    
  // },
  {
    path: 'manage-process',
   loadChildren: () => import(`./manage-process/manage-process.module`).then(m => m.ManageProcessModule),
    
  },
  {
    path: 'run-process',
    loadChildren: () => import(`./run-process/run-process.module`).then(m=> m.RunProcessModule)
    
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
