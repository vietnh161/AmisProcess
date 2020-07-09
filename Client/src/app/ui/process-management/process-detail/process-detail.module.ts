import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { ProcessDetailComponent } from './process-detail.component';
import { DetailProcessRoutingModule } from './process-detail-routing.module';
import { PhaseDetailComponent } from './phase-detail/phase-detail.component';
import { FormsModule } from '@angular/forms';
import { AddFieldComponent } from './phase-detail/add-field/add-field.component';
import { ListFieldComponent } from './phase-detail/list-field/list-field.component';
import { ProcessActionModule } from '../process-action/process-action.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddFieldModule } from './phase-detail/add-field/add-field.module';
import { AddEmployeeComponent } from './phase-detail/add-employee/add-employee.component';

@NgModule({
    declarations: [

        ProcessDetailComponent,
        PhaseDetailComponent,
    //    AddFieldComponent,
        ListFieldComponent,
    AddEmployeeComponent,
       
    ],
    imports: [
        CommonModule,
        ClarityModule,
        FormsModule,
        DetailProcessRoutingModule,
        SharedModule,
        ProcessActionModule,
        AddFieldModule
    ],

})

export class ProcessDetailModule { }