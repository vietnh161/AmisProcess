import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";



@Component({
    selector:'app-list-field',
    templateUrl: './list-field.component.html',
    styleUrls: ['./list-field.component.css'],
})

export class ListFieldComponent implements OnInit {

    @Input() fields:[];
    @Output() onDeleteField = new EventEmitter();

    constructor(){

    }
    ngOnInit(): void {
      console.log(this.fields);
      
    //   setInterval(()=> {
    //       console.log(this.fields);
          
    //   },3000);
    }
    
    emitDelete(id){

        
        this.onDeleteField.emit(id)
    }
}