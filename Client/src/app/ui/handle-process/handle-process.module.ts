
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClarityModule } from '@clr/angular';

import { FormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { HandleProcessRoutingModule } from './handle-process-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { HandleProcessComponent } from './handle-process.component';
import { DetailHandleComponent } from './detail-handle/detail-handle.component';


@NgModule({
    declarations: [

        HandleProcessComponent,
        DetailHandleComponent

    ],
    imports: [
        CommonModule,
        FormsModule,
        ClarityModule,
        HandleProcessRoutingModule,
        SharedModule

    ],
})
export class HandleProcessModule { }
