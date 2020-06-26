import { Component, OnInit, Input, Output,EventEmitter } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services';
import { typeData } from 'src/app/data/type';
@Component({
    selector: 'app-add-field',
    templateUrl: './add-field.component.html',
    styleUrls: ['./add-field.component.css'],
})
export class AddFieldComponent implements OnInit {

    @Input() phase;
    @Input() phases;
    @Input() open;
    @Output() close = new EventEmitter();
    @Output() test = new EventEmitter()

    value;
    options;
    field;
    types = typeData;
   

    constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, ) {
   
       
        this.options = [];
        this.field = {
            name:'',
            description:'',
            type: '',
        }
    }

    ngOnInit(): void {
        
    }

    addFieldHandle(phase) {

        console.log(this.field);
        
        this.phase.field.push(this.field);
        this.field = {
        name:'',
        description:'',
        type: '',
       }
        console.log(this.phase);
        this.test.emit();
        // phase.errorAddField = '';
        // phase.successAddField = '';
        // if (phase.field.name == '' || phase.field.type == '') {
        //     phase.errorAddField = 'Tên hoặc loại không được để trống';
        // } else {


        //     var options = [...phase.fieldTemp.options]
        //     this.phases.find(x => x.id == phase.id).fields.push(newField);
        //     console.log(this.phases.find(x => x.id == phase.id).fields);
        //     phase.fieldTemp.options = [];
        //     phase.fieldTemp.name = '';
        //     phase.fieldTemp.description = '';
        //     phase.fieldTemp.type = '';
        //     phase.fieldTemp.required = false;
        //     phase.successAddField = 'Thành công';
        // }


    }

    addOptionForField( event) {
     
        
        if (event.keyCode == 13) {
            if (this.value != '') {
                var newOption = {
                    id:Math.floor(Math.random() *1000000),
                    value: this.value,
                   
                }
                this.options.push(newOption);
                this.value = '';
            }

        }
        
    }

    deleteOption(optionId){
        this.options.splice(this.options.findIndex(x => x.id == optionId),1);
    }

    closeModal(){
        this.close.emit();
    }
}
