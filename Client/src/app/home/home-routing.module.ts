import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../_helpers/auth.guard';
import { HomeComponent } from './home.component';
import { pathToFileURL } from 'url';
import { TestComponent } from '../test/test.component';
import { MainLayoutComponent } from '../layout/layout.component';


const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        canActivate: [AuthGuard],
        children: [
          //  {
        //    path: '',
        //    component : ListProcessComponent
        //     }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class HomeRoutingModule {

}