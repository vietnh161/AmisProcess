import { Component, OnInit } from '@angular/core';
import { listProcessData } from '../../../data/list-process'
import { phaseData } from '../../../data/phase'
import { listType } from '../../../data/type'
import { employeeData } from '../../../data/employee'
import { categoryData } from '../../../data/category'
import { ActivatedRoute, Router } from '@angular/router';
import { trigger } from '@angular/animations';
import { throwIfEmpty, isEmpty } from 'rxjs/operators';
import { fieldData } from 'src/app/data/field';
import { AuthenticationService } from 'src/app/_services';

@Component({
    selector: 'app-detail-phase',
    templateUrl: './detail-phase.component.html',
    styleUrls: ['./detail-phase.component.css'],
})
export class DetailPhaseComponent implements OnInit {

    currentUser;
    mode;
    processId;
    process;
    phases = [];
    phaseSerial: number;
    listEmployee;

    optionForTime = 'h';
    optionForPerson;


    constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, ) {

        console.log(this.phases);
        

        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
        this.listEmployee = employeeData;

        this.mode = this.route.snapshot.paramMap.get("mode");
        this.processId = this.route.snapshot.paramMap.get("id");
        this.phaseSerial = parseInt(this.route.snapshot.paramMap.get("serial"));
        this.process = listProcessData.find(x => x.id == this.processId);
        if (this.process == null) {
            this.router.navigateByUrl('notfound');

        }

        for (let i = 0; i < phaseData.length; i++) {
            if (phaseData[i].processId == this.processId) {
                this.phases[i] = {};
                Object.assign(this.phases[i], phaseData[i])

            }

        }

        this.phases = this.phases.filter((el) => {
            return el != null;
        });

        if(this.phaseSerial > this.phases.map(x=> x.serial).reduce((x,y) => Math.max(x,y)) ){
            this.router.navigateByUrl('notfound');
        }

        if (this.mode == 'edit') {

            this.phases.forEach(x => {
                if (x.serial == this.phaseSerial) x.active = true;
                x.fieldTemp = {
                    id: null,
                    name: '',
                    description: '',
                    type: '',
                    valueOption: '',
                    options: [],
                    required: false,
                    pharseId: null,
                };
                x.employeeCodeTemp = null;
                x.errorAddPerson = '';


            })



        } else if (this.mode == 'add') {
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
                    x.active = false;
                }

                x.fieldTemp = {
                    id: null,
                    name: '',
                    description: '',
                    type: '',
                    valueOption: '',
                    options: [],
                    required: false,
                    pharseId: null,
                };
                x.employeeCodeTemp = null;
                x.errorAddPerson = '';
                x.errorAddField = '';
                x.successAddPerson = '';
                x.successAddField = '';
            })

        } else {
            router.navigateByUrl('notfound');
        }



        this.phases.sort((x, y) => x.serial - y.serial);

    }

    ngOnInit(): void {

    }

    addPersonHandle(phase, event) {
        phase.errorAddPerson = '';
        phase.successAddPerson = ''
        if (event.keyCode == 13) {
            event.preventDefault();
            var employee = this.listEmployee.find(x => x.employeeCode == phase.employeeCode)
            if (employee != null) {
                phase.personImplement.push(employee);
                phase.employeeCode = '';
                phase.successAddPerson = 'Thành công'
            } else {
                phase.errorAddPerson = 'Nhân viên không tồn tại'
            }
        }

    }

    deletePersonHandle(phase, id) {

        var listPerson = this.phases.find(x => x.id == phase.id).personImplement;
        // console.log(listPerson);
        // console.log(this.phases.find(x=> x.id == phase.id).personImplement);
        //  console.log(id);

        listPerson.splice(listPerson.findIndex(x => x.id == id), 1)
    }



    deleteFieldHandle(phase, id) {
        var listField = this.phases.find(x => x.id == phase.id).fields;
        listField.splice(listField.findIndex(x => x.id == id), 1)
    }


    submitHandle(item) {
        // console.log(item);

        if (item.description == '' || item.timeImplement == null) {
            return;
        } else {

            console.log(this.phases);


            phaseData.forEach(x => {
                if (x.processId == this.processId) {
                    phaseData.splice(phaseData.indexOf(x));
                }

            })

            this.phases.forEach(x => {
                delete x.fieldTemp;
                delete x.employeeCodeTemp;
                delete x.errorAddPerson;
                delete x.errorAddField;
                delete x.successAddPerson;
                delete x.successAddField;
                phaseData.push(x);
            })

            this.process.updatedTime = new Date();
            this.process.updatedBy = this.currentUser.firstName + ' ' + this.currentUser.lastName;
            //  console.log(phaseData);
            this.router.navigateByUrl('manage-process/process/' + this.processId);

        }
    }


    cancelHandle(event) {
        event.preventDefault();
        this.router.navigateByUrl('manage-process/process/' + this.processId)
    }

    deleteHandle(phase) {

        this.phases.forEach(x => {
            if (x.serial > phase.serial) x.serial--;
            if (x.serial == phase.serial) x.active = true;
        })
        this.phases = this.phases.filter(x => x.id != phase.id);
    }

    addPhaseHandle(item, e) {
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
                valueOption: '',
                options: [],
                required: false,
                pharseId: null,
            },
            employeeCodeTemp: null,
            errorAddPerson: '',
            errorAddField: '',
            successAddField: '',
            successAddPerson: '',
        }

        newPhase.serial = item.serial + 1;
        this.phases.forEach(x => {
            if (x.serial >= newPhase.serial) {
                x.serial++;
                x.active = false;
            }

        })

        this.phases.push(newPhase);
        this.phases = this.phases.sort((x, y) => x.serial - y.serial);
        console.log(this.phases)
    }

    showValue() {
        console.log(this.optionForTime);

    }

    test(e) {
        e.preventDefault()
        console.log('a');
    }
}
