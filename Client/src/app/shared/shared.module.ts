
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { FormsModule } from '@angular/forms';
import { AutofocusDirectiveModule } from './directive/autofocus.directive';


@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    ClarityModule,
    FormsModule,
    AutofocusDirectiveModule
  ],
  exports:[
    AutofocusDirectiveModule
  ]
})
export class SharedModule { }
