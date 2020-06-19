
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { ListProcessComponent } from './list-process.component';
import { AutofocusDirectiveModule } from 'src/app/common/directive/autofocus.directive';


@NgModule({
  declarations: [

   ListProcessComponent,
  ],
  imports: [
    CommonModule,
    ClarityModule,
    AutofocusDirectiveModule,
  ],
})
export class ListProcessModule { }
