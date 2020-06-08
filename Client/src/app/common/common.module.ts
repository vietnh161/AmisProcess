
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { SearchListComponent } from './search/search-list.component';
import { SelectComponent } from './select/select.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [

   SearchListComponent,
   SelectComponent,
   
  ],
  imports: [
    CommonModule,
    ClarityModule,
    FormsModule
  ],
  exports:[
    SearchListComponent,
    SelectComponent,
  ]
})
export class CustomCommonModule { }
