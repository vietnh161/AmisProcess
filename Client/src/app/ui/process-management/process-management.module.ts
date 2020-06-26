
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProcessManagementComponent } from './process-management.component';
import { ProcessManagementRoutingModule } from './process-management-routing.module';
import { ClarityModule } from '@clr/angular';
import { ProcessListComponent } from './process-list/process-list.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AutofocusDirectiveModule } from 'src/app/shared/directive/autofocus.directive';
import { ProcessActionComponent } from './process-action/process-action.component';
import { ProcessActionModule } from './process-action/process-action.module';



@NgModule({
  declarations: [

    ProcessManagementComponent,
    ProcessListComponent,

  ],
  imports: [
    CommonModule,
    FormsModule,
    ProcessManagementRoutingModule,
    ProcessActionModule,
    ClarityModule,
    SharedModule,
    AutofocusDirectiveModule
  ],
})
export class ProcessManagementModule { }
