import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { DetailProcessComponent } from './detail-process.component';
import { DetailProcessRoutingModule } from './detail-process-routing.module';
import { AddPhaseComponent } from './add-phase/add-phase.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [

        DetailProcessComponent,
        AddPhaseComponent

    ],
    imports: [
        CommonModule,
        ClarityModule,
        FormsModule,
        DetailProcessRoutingModule
    ],

})

export class DetailProcessModule { }