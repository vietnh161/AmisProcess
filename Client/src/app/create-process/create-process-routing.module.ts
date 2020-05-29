import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

import { AuthGuard } from '../_helpers/auth.guard';
import { pathToFileURL } from 'url';
import { TestComponent } from '../test/test.component';
import { MainLayoutComponent } from '../layout/layout.component';
import { CreateProcessComponent } from './create-process.component';


const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        canActivate: [AuthGuard],
        data: {role: ['Admin']},
        children: [
            {
           path: '',
           component : CreateProcessComponent
            }
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CreateProcessRoutingModule {

}