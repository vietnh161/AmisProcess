import { Component, OnInit, Input, Output,EventEmitter, ViewChild, ElementRef } from '@angular/core';
import {v4 as uuidv4} from 'uuid';

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
    @Input() open;
    @Output() close = new EventEmitter();

    @ViewChild("nameInput",{read: ElementRef}) nameInPut: ElementRef;
    @ViewChild("typeInput",{read: ElementRef}) typeInput: ElementRef;
    @ViewChild("optionInput",{read: ElementRef}) optionInput: ElementRef;


    value;
    field;
    types = typeData;
    errorAddField:string ;
    successAddField:string ;

    constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, ) {
   
        this.errorAddField = '';
        this.successAddField = '';
      
        
    }

    ngOnInit(): void {
        this.field = this.resetField()
    }

    addFieldHandle() {
      
       
        this.errorAddField = '';
        this.successAddField = '';
        if (this.field.name == '') {
            this.errorAddField = 'Tên không được để trống';
            this.nameInPut.nativeElement.focus();
            return;
        }else if(this.field.type == ''){
            this.errorAddField = 'Loại không được để trống';
            this.typeInput.nativeElement.focus();
            return;
        } else if(this.field.type == 'Radio' || this.field.type =='Check Box') {
            if( this.field.fieldOption.length == 0){
                this.errorAddField = 'Option không được để trống';
                this.optionInput.nativeElement.focus();
                return;
            }
           
        } 
        

            this.phase.field.push(this.field);
            this.field = this.resetField();
            console.log(this.field.fieldOption);
              this.optionInput.nativeElement.focus();
            this.successAddField = 'Thành công';
            this.nameInPut.nativeElement.focus();
        


    }

    addOptionForField( event) {
     
        
        if (event.keyCode == 13) {
            if (this.value != '') {
                var newOption = {
                    id: uuidv4(),
                    value: this.value,
                   
                }
                this.field.fieldOption.push(newOption);
                this.value = '';
            }

        }
        
    }

    deleteOption(optionId){
       this.field.fieldOption.splice(this.field.fieldOption.findIndex(x => x.id == optionId),1);
    }

    closeModal(){
        this.close.emit();
    }

    resetField(){
        return  {
            fieldId: uuidv4(),
            name:'',
            description:'',
            type: '',
            fieldOption: [],
            required: false,
            phaseId: this.phase.phaseId,
        }
    }

}
