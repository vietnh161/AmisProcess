import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



import { AuthGuard } from './_helpers';
import { from } from 'rxjs';

import { LoginComponent } from './pages/login/login.component';
import { MainLayoutComponent } from './pages/main-page/layout.component';
import { Page404Component } from './pages/page404/page404.component';

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
   loadChildren: () => import(`./components/manage-process/manage-process.module`).then(m => m.ManageProcessModule),
    
  },
  {
    path: 'handle-process',
    loadChildren: () => import(`./components/handle-process/handle-process.module`).then(m=> m.HandleProcessModule)
    
  },
  {
    path: 'run-process',
    loadChildren: () => import(`./components/run-process/run-process.module`).then(m=> m.RunProcessModule)
    
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
