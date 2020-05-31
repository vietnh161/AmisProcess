import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

// import { AuthGuard } from '../_helpers/auth.guard';
import { DetailProcessComponent } from './detail-process.component';


const routes: Routes = [
    {
        path: '',
        component: DetailProcessComponent,
        children: [
           
        ]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class DetailProcessRoutingModule {

}