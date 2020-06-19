import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { DetailProcessComponent } from './detail-process.component';
import { DetailProcessRoutingModule } from './detail-process-routing.module';
import { DetailPhaseComponent } from './detail-phase/detail-phase.component';
import { FormsModule } from '@angular/forms';
import { AddFieldComponent } from './detail-phase/add-field/add-field.component';
import { ListFieldComponent } from './detail-phase/list-field/list-field.component';
import { AutofocusDirectiveModule } from 'src/app/common/directive/autofocus.directive';

@NgModule({
    declarations: [

        DetailProcessComponent,
        DetailPhaseComponent,
        AddFieldComponent,
        ListFieldComponent
       
    ],
    imports: [
        CommonModule,
        ClarityModule,
        FormsModule,
        DetailProcessRoutingModule,
        AutofocusDirectiveModule
    ],

})

export class DetailProcessModule { }