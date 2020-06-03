import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

// import { AuthGuard } from '../_helpers/auth.guard';
import { DetailProcessComponent } from './detail-process.component';
import { DetailPhaseComponent } from './detail-phase/detail-phase.component';


const routes: Routes = [
    {
        path: '',
        component: DetailProcessComponent,
    },
    {
        path: ':mode/:serial',
        component: DetailPhaseComponent,


    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class DetailProcessRoutingModule {

}