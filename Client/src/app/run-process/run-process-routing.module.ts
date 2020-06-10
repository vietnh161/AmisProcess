import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../_helpers/auth.guard';

import { MainLayoutComponent } from '../layout/layout.component';
import { RunProcessComponent } from './run-process.component';
import { DetailRunComponent } from './detail-run/detail-run.component';


const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        //   canActivate: [AuthGuard],
        children: [
            // {
            //     path: '',
            //     redirectTo: 'list-process',
            //     pathMatch: 'full'
            // },
            {
                path: '',
                data:
                {
                    title: 'Danh sách quy trình',
                },
                component: RunProcessComponent,

            },
            {
                path: ':id',
                component: DetailRunComponent,

            }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class RunProcessRoutingModule {

}