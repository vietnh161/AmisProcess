
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'misa-selectbox',
    templateUrl: './selectbox.component.html',
    styleUrls: ['./selectbox.component.css'],
})
export class SelectBoxComponent implements OnInit {

    @Input() label:string;
    @Input() options;
    @Output() emitValue = new EventEmitter();

    optionSelected:string;

    constructor( ) {

    }


    ngOnInit(): void {
        this.optionSelected = this.options[0].name;
        this.emitValue.emit(this.optionSelected)
    }

    emitOptionValue(){
        this.emitValue.emit(this.optionSelected)
    }
}
