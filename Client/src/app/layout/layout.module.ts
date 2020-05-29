import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayoutComponent } from './layout.component';
import { RouterModule } from '@angular/router';
import { ClarityModule } from '@clr/angular';

@NgModule({
  imports: [
    CommonModule,
    ClarityModule,
    RouterModule.forChild([]),
  ],
  exports: [
    MainLayoutComponent
  ],
  declarations: [
    MainLayoutComponent,
    
  ]
})
export class LayoutModule { }
