
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageProcessComponent } from './manage-process.component';
import { ManageProcessRoutingModule } from './manage-process-routing.module';
import { ClarityModule } from '@clr/angular';
import { ListProcessComponent } from './list-process/list-process.component';


@NgModule({
  declarations: [

   ManageProcessComponent,
  ListProcessComponent
   
  ],
  imports: [
    CommonModule,
    ClarityModule,
    ManageProcessRoutingModule,
    
  ],
})
export class ManageProcessModule { }
