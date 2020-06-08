
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClarityModule } from '@clr/angular';

import { FormsModule } from '@angular/forms';

import { SearchListComponent } from '../common/search/search-list.component';
import { SelectComponent } from '../common/select/select.component';
import { RunProcessComponent } from './run-process.component';
import { RunProcessRoutingModule } from './run-process-routing.module';
import { CustomCommonModule } from '../common/common.module';
import { FirstPhaseComponent } from './first-phase/first-phase.component';


@NgModule({
    declarations: [

        RunProcessComponent,
        FirstPhaseComponent

    ],
    imports: [
        CommonModule,
        FormsModule,
        ClarityModule,
        RunProcessRoutingModule,
        CustomCommonModule

    ],
})
export class RunProcessModule { }
