
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { ProcessListComponent } from './process-list.component';
import { AutofocusDirectiveModule } from 'src/app/shared/directive/autofocus.directive';
import { ProcessActionComponent } from '../process-action/process-action.component';


@NgModule({
  declarations: [
    ProcessListComponent,
  ],
  imports: [
    CommonModule,
    ClarityModule,
    AutofocusDirectiveModule,
  ],
})
export class ListProcessModule { }
