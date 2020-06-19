import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../../_helpers/auth.guard';


import { ListProcessComponent } from './list-process/list-process.component';
import { DetailProcessComponent } from './detail-process/detail-process.component';
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
                path: 'list-process',
                data:
                {
                    title: 'Danh sách quy trình',
                },
                component: ListProcessComponent,

            },
            {
                path: 'process/:id',
               // component: DetailProcessComponent
                loadChildren: () => import(`./detail-process/detail-process.module`).then(m => m.DetailProcessModule),

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