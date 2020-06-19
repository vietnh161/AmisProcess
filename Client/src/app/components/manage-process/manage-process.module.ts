
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageProcessComponent } from './manage-process.component';
import { ManageProcessRoutingModule } from './manage-process-routing.module';
import { ClarityModule } from '@clr/angular';
import { ListProcessComponent } from './list-process/list-process.component';
import { FormsModule } from '@angular/forms';
import { AddProcessComponent } from './list-process/add-process/add-process.component';
import { CustomCommonModule } from 'src/app/common/common.module';
import { AutofocusDirectiveModule } from 'src/app/common/directive/autofocus.directive';



@NgModule({
  declarations: [

   ManageProcessComponent,
  ListProcessComponent,
  AddProcessComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ClarityModule,
    ManageProcessRoutingModule,
    CustomCommonModule,
    AutofocusDirectiveModule
  ],
})
export class ManageProcessModule { }
