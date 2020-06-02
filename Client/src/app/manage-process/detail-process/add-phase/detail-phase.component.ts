import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { listProcessData } from '../../../data/list-process'
import { phaseData } from '../../../data/phase'
import { listType } from '../../../data/type'
import { employeeData } from '../../../data/employee'
import { categoryData } from '../../../data/category'
import { ActivatedRoute, Router } from '@angular/router';
import { trigger } from '@angular/animations';
import { throwIfEmpty } from 'rxjs/operators';
import { fieldData } from 'src/app/data/field';

@Component({
    selector: 'app-detail-phase',
    templateUrl: './detail-phase.component.html',
    styleUrls: ['./detail-phase.component.css'],
})
export class DetailPhaseComponent implements OnInit {

    mode;
    processId;
    process;
    phases = [];
    phaseSerial: number;
    listEmployee;

    optionForTime = 'h';
    optionForPerson;

    types = listType;

    constructor(private route: ActivatedRoute, private router: Router, private cdr: ChangeDetectorRef) {

        this.listEmployee = employeeData;

        this.mode = this.route.snapshot.paramMap.get("mode");
        this.processId = this.route.snapshot.paramMap.get("id");
        this.phaseSerial = parseInt(this.route.snapshot.paramMap.get("serial"));
        this.process = listProcessData.find(x => x.id == this.processId);
        if (this.process == null) {
            this.router.navigateByUrl('notfound');
        }

        for (var i = 0; i < phaseData.length; i++) {
            if (phaseData[i].processId == this.processId) {
                this.phases[i] = {};
                Object.assign(this.phases[i], phaseData[i])
            }

        }

        if(this.mode == 'edit'){
           
            this.phases.forEach(x => {
                if(x.serial == this.phaseSerial) x.active = true;
                x.fieldTemp = {
                    id: null,
                    name: '',
                    description: '',
                    type: '',
                    required: false,
                    pharseId: null,
                };
                x.employeeCodeTemp = null;
                x.errorAddPerson = '';
    
            })


        }else if(this.mode == 'add'){
            var newPhase = {
                id: phaseData.map(x => x.id).reduce((x, y) => Math.max(x, y)) + 1,
                serial: null,
                name: 'Giai đoạn mới',
                description: '',
                canDel: true,
                timeImplementType: '',
                timeImplement: null,
                personImplementType: 'all',
                personImplement: [],
                fields: [],
                processId: parseInt(this.processId),
                active: true
            }
    
            newPhase.serial = this.phaseSerial + 1;
            this.phases.push(newPhase);
            this.phases.forEach(x => {
                if (x.serial >= newPhase.serial && x.id != newPhase.id) {
                    x.serial++;
                }
    
                x.fieldTemp = {
                    id: null,
                    name: '',
                    description: '',
                    type: '',
                    required: false,
                    pharseId: null,
                };
                x.employeeCodeTemp = null;
                x.errorAddPerson = '';
    
            })

        }else{
           router.navigateByUrl('notfound') ;
        }

       

        this.phases.sort((x, y) => x.serial - y.serial);

    }

    ngOnInit(): void {

    }

    addPersonHandle(phase, event) {
        phase.errorAddPerson = ''
        if (event.keyCode == 13) {
            event.preventDefault();
            var employee = this.listEmployee.find(x => x.employeeCode == phase.employeeCode)
            if (employee != null) {
                phase.personImplement.push(employee);
                phase.employeeCode = '';

            } else {
                phase.errorAddPerson = 'Nhân viên không tồn tại'
            }
        }

    }

    deletePersonHandle(phase,id){

        var listPerson = this.phases.find(x=> x.id == phase.id).personImplement;
        // console.log(listPerson);
        // console.log(this.phases.find(x=> x.id == phase.id).personImplement);
        //  console.log(id);
         
         listPerson.splice(listPerson.findIndex(x => x.id == id),1)
    }


    addFieldHandle(phase) {
        var newField = { ...phase.fieldTemp }
        newField.id = fieldData.map(x => x.id).reduce((a, b) => Math.max(a, b))+1;
        fieldData.push(newField);
        this.phases.find(x => x.id == phase.id).fields.push(newField)
    }

    handleSubmit(item) {
        // console.log(item);

        if (item.description == '' || item.timeImplement == null) {
            return;
        } else {

            // console.log(phaseClone);


            phaseData.forEach(x => {
                if (x.id == this.processId) {
                    phaseData.splice(phaseData.indexOf(x));
                }
            })

            this.phases.forEach(x => {
                delete x.fieldTemp;
                delete x.employeeCodeTemp;
                delete x.errorAddPerson;
                phaseData.push(x)
            })

            this.router.navigateByUrl('manage-process/process/' + this.processId);

        }
    }

    handleCancel(event) {
        event.preventDefault();
        this.router.navigateByUrl('manage-process/process/' + this.processId)
    }

    handleAddPhase(item, e) {
        e.preventDefault();
        var newPhase = {
            id: phaseData.map(x => x.id).reduce((x, y) => Math.max(x, y)) + 1,
            serial: null,
            name: 'Giai đoạn mới',
            description: '',
            canDel: true,
            timeImplementType: '',
            timeImplement: null,
            personImplementType: 'all',
            personImplement: [],
            fields: [],
            processId: parseInt(this.processId),
            active: true,

            fieldTemp: {
                id: null,
                name: '',
                description: '',
                type: '',
                required: false,
                pharseId: null,
            },
            employeeCodeTemp: null,
            errorAddPerson: ''
        }

        newPhase.serial = item.serial + 1;
        this.phases.forEach(x => {
            if (x.serial >= newPhase.serial) {
                x.serial++;
            }

        })
     
        this.phases.push(newPhase);
        this.phases = this.phases.sort((x, y) => x.serial - y.serial);
    }

    showValue() {
        console.log(this.optionForTime);

    }

    test(e) {
        e.preventDefault()
        console.log('a');
    }
}
