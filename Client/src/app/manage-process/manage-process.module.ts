
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageProcessComponent } from './manage-process.component';
import { ManageProcessRoutingModule } from './manage-process-routing.module';
import { ClarityModule } from '@clr/angular';
import { ListProcessComponent } from './list-process/list-process.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [

   ManageProcessComponent,
  ListProcessComponent
   
  ],
  imports: [
    CommonModule,
    FormsModule,
    ClarityModule,
    ManageProcessRoutingModule,
    
  ],
})
export class ManageProcessModule { }
