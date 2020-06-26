import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { ProcessDetailComponent } from './process-detail.component';
import { DetailProcessRoutingModule } from './process-detail-routing.module';
import { PhaseDetailComponent } from './phase-detail/phase-detail.component';
import { FormsModule } from '@angular/forms';
import { AddFieldComponent } from './phase-detail/add-field/add-field.component';
import { ListFieldComponent } from './phase-detail/list-field/list-field.component';
import { AutofocusDirectiveModule } from 'src/app/shared/directive/autofocus.directive';
import { ProcessActionModule } from '../process-action/process-action.module';

@NgModule({
    declarations: [

        ProcessDetailComponent,
        PhaseDetailComponent,
        AddFieldComponent,
        ListFieldComponent,
       
    ],
    imports: [
        CommonModule,
        ClarityModule,
        FormsModule,
        DetailProcessRoutingModule,
        AutofocusDirectiveModule,
        ProcessActionModule,
    ],

})

export class ProcessDetailModule { }