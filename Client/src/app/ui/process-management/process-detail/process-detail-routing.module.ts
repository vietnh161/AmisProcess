import { Routes, RouterModule } from "@angular/router";
import { NgModule, Component } from '@angular/core';

// import { AuthGuard } from '../../_helpers/auth.guard';
import { ProcessDetailComponent } from './process-detail.component';
import { PhaseDetailComponent } from './phase-detail/phase-detail.component';


const routes: Routes = [
    {
        path: '',
        component: ProcessDetailComponent,
    },
    {
        path: ':mode/:serial',
        component: PhaseDetailComponent,


    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class DetailProcessRoutingModule {

}