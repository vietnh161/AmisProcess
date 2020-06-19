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
        
    }
    
    emitDelete(id){

        
        this.onDeleteField.emit(id)
    }
}