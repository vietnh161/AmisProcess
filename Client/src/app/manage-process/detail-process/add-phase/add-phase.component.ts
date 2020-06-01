import { Component, OnInit } from '@angular/core';
import { listProcessData } from '../../../data/list-process'
import { phaseData } from '../../../data/phase'
import { listType } from '../../../data/type'
import { employeeData } from '../../../data/employee'
import { categoryData } from '../../../data/category'
import { ActivatedRoute, Router } from '@angular/router';
import { trigger } from '@angular/animations';

@Component({
    selector: 'app-add-phase',
    templateUrl: './add-phase.component.html',
    styleUrls: ['./add-phase.component.css'],
})
export class AddPhaseComponent implements OnInit {

    processId;
    process;
    phases;
    phaseSerial:number;
    listEmployee;
    employeeCode;
    fieldAdd = {
        id: null,
        name: '',
        description: '',
        type: '',
        required: false,
        pharseId: null,
    }

    newPhase = {
        id: null,
        serial: null,
        name: 'Giai đoạn mới',
        description: '',
        timeImplementType:'',
        timeImplement: null,
        personImplementType:'all',
        personImplement: [],
        fields: [],
        processId: null,
        active:true
    };

    optionForTime = 'h';
    optionForPerson;

    types = listType;

    constructor(private route: ActivatedRoute,private router: Router) {
        this.listEmployee = employeeData;

        this.processId =  this.route.snapshot.paramMap.get("id");
        this.phaseSerial =  parseInt(this.route.snapshot.paramMap.get("serial"));
        this.process = listProcessData.find(x=> x.id == this.processId);
        if(this.process == null ){
            this.router.navigateByUrl('notfound');
        }
        this.newPhase.serial = this.phaseSerial + 1;
        phaseData.forEach(x => {
            if(x.serial >= this.newPhase.serial ){
                x.serial++;
            }
        })
        this.newPhase.processId = this.processId;
        phaseData.push(this.newPhase);
        this.phases = phaseData.filter(x => x.processId == this.processId).sort((x,y) => x.serial - y.serial)
        
    }

    ngOnInit(): void {
        
    }

    addPersonHandle(id, event){
        if(event.keyCode == 13){
            event.preventDefault();
            var employee = this.listEmployee.find(x => x.employeeCode == this.employeeCode)
            if(employee != null){
                var phase = this.phases.find(x=>x.id == id);
                phase.personImplement.push(employee);
                this.employeeCode = '';
            }
        }   
        
    }

    addFieldHandle(phaseId){
        var newField = {...this.fieldAdd}

        phaseData.find(x=> x.id == phaseId).fields.push(newField)
      }

    handleSubmit(item){
       // console.log(item);

        if(item.description == '' || item.timeImplement == null){
            return;
        }
        console.log(item);
        
    }

    handleCancel(event){
        event.preventDefault()
    }

    showValue(){
        console.log(this.optionForTime);
        
    }
}
