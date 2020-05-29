
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateProcessComponent } from './create-process.component';
import { CreateProcessRoutingModule } from './create-process-routing.module';




@NgModule({
  declarations: [

    CreateProcessComponent,
  
   
  ],
  imports: [
    CommonModule,
    CreateProcessRoutingModule,
     
  ],
})
export class CreateProcessModule { }
