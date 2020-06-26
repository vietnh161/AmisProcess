
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClarityModule } from '@clr/angular';
import { SearchListComponent } from './search/search-list.component';
import { SelectBoxComponent } from './select/selectbox.component';
import { FormsModule } from '@angular/forms';
import { AutofocusDirectiveModule } from './directive/autofocus.directive';


@NgModule({
  declarations: [

   SearchListComponent,
   SelectBoxComponent,
  ],
  imports: [
    CommonModule,
    ClarityModule,
    FormsModule,
    AutofocusDirectiveModule
  ],
  exports:[
    SearchListComponent,
    SelectBoxComponent,
  ]
})
export class SharedModule { }
