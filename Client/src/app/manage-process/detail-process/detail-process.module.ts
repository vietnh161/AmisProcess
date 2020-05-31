import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { DetailProcessComponent } from './detail-process.component';
import { DetailProcessRoutingModule } from './detail-process-routing.module';

@NgModule({
    declarations: [

        DetailProcessComponent


    ],
    imports: [
        CommonModule,
        ClarityModule,
        DetailProcessRoutingModule
    ],

})

export class DetailProcessModule { }