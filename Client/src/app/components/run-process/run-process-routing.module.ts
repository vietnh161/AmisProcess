import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../../_helpers/auth.guard';


import { RunProcessComponent } from './run-process.component';
import { DetailRunComponent } from './detail-run/detail-run.component';
import { MainLayoutComponent } from 'src/app/pages/main-page/layout.component';


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
                    title: 'Chạy quy trình ',
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