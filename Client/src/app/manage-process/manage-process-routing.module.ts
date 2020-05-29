import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../_helpers/auth.guard';

import { MainLayoutComponent } from '../layout/layout.component';
import { ListProcessComponent } from './list-process/list-process.component';


const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path: '',
                redirectTo: 'list-process',
                pathMatch: 'full'
            },
            {
                path: 'list-process',
               component: ListProcessComponent,
                
            }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ManageProcessRoutingModule {

}