
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClarityModule } from '@clr/angular';

import { FormsModule } from '@angular/forms';


import { RunProcessComponent } from './run-process.component';
import { RunProcessRoutingModule } from './run-process-routing.module';

import { DetailRunComponent } from './detail-run/detail-run.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
    declarations: [

        RunProcessComponent,
        DetailRunComponent

    ],
    imports: [
        CommonModule,
        FormsModule,
        ClarityModule,
        RunProcessRoutingModule,
        SharedModule

    ],
})
export class RunProcessModule { }
