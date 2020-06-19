import { Component, OnInit, Input, Output,EventEmitter } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';
import {fieldData} from '../../../../../data/field'
import { listType } from 'src/app/data/type';
@Component({
    selector: 'app-add-field',
    templateUrl: './add-field.component.html',
    styleUrls: ['./add-field.component.css'],
})
export class AddFieldComponent implements OnInit {

    @Input() phase;
    @Input() phases;
    @Input() open;
    @Output() close = new EventEmitter()

    types = listType;
   

    constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, ) {
   
    }

    ngOnInit(): void {

    }

    addFieldHandle(phase) {
        phase.errorAddField = '';
        phase.successAddField = '';
        if (phase.fieldTemp.name == '' || phase.fieldTemp.type == '') {
            phase.errorAddField = 'Tên hoặc loại không được để trống';
        } else {


            let newField = <any>{};
            Object.assign(newField, phase.fieldTemp);

            console.log(newField);


            var options = [...phase.fieldTemp.options]
            // options[1] = 'aa'
            // console.log(newField);
            // console.log(options);

            // console.log(newField);

            newField.id = fieldData.map(x => x.id).reduce((a, b) => Math.max(a, b)) + 1;
            //  fieldData.push(newField);
            this.phases.find(x => x.id == phase.id).fields.push(newField);
            console.log(this.phases.find(x => x.id == phase.id).fields);
            phase.fieldTemp.options = [];
            phase.fieldTemp.name = '';
            phase.fieldTemp.description = '';
            phase.fieldTemp.type = '';
            phase.fieldTemp.required = false;
            phase.successAddField = 'Thành công';
        }


    }

    addOptionForField(field, event) {
        if (event.keyCode == 13) {
            if (field.fieldTemp.valueOption != '') {
                var newOption = {
                    id:Math.floor(Math.random() *10000),
                    value: field.fieldTemp.valueOption
                }
                field.fieldTemp.options.push(newOption);
                field.fieldTemp.valueOption = '';
            }

        }
    }

    deleteOption(options,optionId){
        options.splice(options.findIndex(x => x.id == optionId),1);
    }

    closeModal(){
        this.close.emit();
    }
}
