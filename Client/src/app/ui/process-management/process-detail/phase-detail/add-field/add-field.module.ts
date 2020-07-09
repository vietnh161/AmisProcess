import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddFieldComponent } from './add-field.component';



@NgModule({
  declarations: [
    AddFieldComponent,
  ],
  imports: [
    CommonModule,
    ClarityModule,
    FormsModule,
    SharedModule,
  ],
  exports: [
    AddFieldComponent
  ]
})
export class AddFieldModule { }
