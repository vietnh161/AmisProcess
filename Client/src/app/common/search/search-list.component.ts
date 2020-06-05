
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-search-list',
    templateUrl: './search-list.component.html',
    styleUrls: ['./search-list.component.css'],
})
export class SearchListComponent implements OnInit {

    @Input() options;
 //   @Output() emitterOption = new EventEmitter();
    @Output() emitterValue = new EventEmitter();

    searchValue: string;
    optionSelected;

    constructor( ) {
      
    }


    ngOnInit(): void {
      // this.optionSelected = this.options[0].name;
       
    }

    emitSearchValue(e){
       
         if(e.keyCode == 13 && this.searchValue != ''){
            this.emitterValue.emit({searchValue:  this.searchValue , optionSelected: this.optionSelected});
         }
        
    }
    setOptionFilter(e){
       this.optionSelected = e;
    }
}
