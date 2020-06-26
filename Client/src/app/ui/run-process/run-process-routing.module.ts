import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../../helpers/auth.guard';


import { RunProcessComponent } from './run-process.component';
import { DetailRunComponent } from './detail-run/detail-run.component';
import { MainPageComponent } from 'src/app/pages/main-page/main-page.component';


const routes: Routes = [
    {
        path: '',
        component: MainPageComponent,
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