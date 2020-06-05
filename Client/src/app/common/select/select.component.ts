
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-select',
    templateUrl: './select.component.html',
    styleUrls: ['./select.component.css'],
})
export class SelectComponent implements OnInit {

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
