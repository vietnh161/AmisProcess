import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../../helpers/auth.guard';


import { ProcessListComponent } from './process-list/process-list.component';
import { ProcessDetailComponent } from './process-detail/process-detail.component';
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
                path: 'list-process',
                data:
                {
                    title: 'Danh sách quy trình',
                },
                component: ProcessListComponent,

            },
            {
                path: 'process/:id',
               // component: DetailProcessComponent
                loadChildren: () => import(`./process-detail/process-detail.module`).then(m => m.ProcessDetailModule),

            }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ProcessManagementRoutingModule {

}