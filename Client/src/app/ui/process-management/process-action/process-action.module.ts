import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProcessActionComponent } from './process-action.component';
import { ClarityModule } from '@clr/angular';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ProcessActionComponent,
  ],
  imports: [
    CommonModule,
    ClarityModule,
    FormsModule
  ],
  exports: [
    ProcessActionComponent
  ]
})
export class ProcessActionModule { }
