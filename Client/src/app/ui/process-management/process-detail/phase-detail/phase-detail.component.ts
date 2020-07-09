import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { trigger } from '@angular/animations';
import { throwIfEmpty, isEmpty, debounceTime, filter, map, distinctUntilChanged, mergeMap, delay } from 'rxjs/operators';
import {v4 as uuidv4} from 'uuid';

import { AuthenticationService } from 'src/app/services';
import { PhaseService } from 'src/app/services/phase.service';
import { EmployeeService } from 'src/app/services/employee.service';
import {  fromEvent, of } from 'rxjs';
import { ProcessService } from 'src/app/services/process.service';


@Component({
    selector: 'app-phase-detail',
    templateUrl: './phase-detail.component.html',
    styleUrls: ['./phase-detail.component.css'],
})
export class PhaseDetailComponent implements OnInit {

    currentUser;
    mode;
    processId;
    process;
    listPhase;
    phaseSerial: number;
    listEmployee;
   
    modifiedPhase;

    saveAllState:boolean;

    @ViewChild("employeeInput") employeeInput : ElementRef;

    constructor(private route: ActivatedRoute, 
        private router: Router, 
        private authenticationService: AuthenticationService,
        private phaseService: PhaseService,
        private processService: ProcessService,
        private employeeService: EmployeeService
         ) {
            this.processId = this.route.snapshot.paramMap.get("id");
            this.mode = this.route.snapshot.paramMap.get("mode");
            this.phaseSerial = parseInt(this.route.snapshot.paramMap.get("serial"));

            this.modifiedPhase = {
                listPhaseDelete : [],
                listFieldDelete : [],
                listEmployeeDelete: [],
                phase: [],
                processId: this.processId,
            }


    }
    ngOnInit(): void {
       
        this.processService.getIncludeById(this.processId).subscribe( // get data
            result => {
                this.process = result;
                this.listPhase = result.phase;
                if(this.listPhase.find(x=> x.serial == this.phaseSerial) == null ){ //check serial không có thì chuyển tới trang notfound
                  this.router.navigateByUrl('notfound');
                 }

                 if(this.mode == 'edit'){
                        this.listPhase.forEach(x => {
                            if (x.serial == this.phaseSerial) x.active = true;
                        });
                       
                 }else if(this.mode == 'add'){

                    var newPhase = this.createNewPhase(this.phaseSerial);
                
                        this.listPhase.forEach(x => {                   
                                    if (x.serial >= newPhase.serial) {  
                                        x.serial++;                      // Tăng thứ tự phase đứng phía sau phase vừa thêm
                                    }                                   
                                });
                        this.listPhase.push(newPhase);
                                
                 }else{
                    this.router.navigateByUrl('notfound');
                 }

                 this.listPhase.sort((x, y) => x.serial - y.serial);    // Sắp xếp lại thứ tự phase

            },
            error => {
                console.log(error);
                this.router.navigateByUrl('notfound');
            }
        )

    }
    
    addEmployeeHandle(phase, event) {
        phase.errorAddPerson = '';
        phase.successAddPerson = '';
      //  console.log(event);
        
        var newPhaseEmployee = {
            phaseEmployeeId: uuidv4(),
            phaseId: phase.phaseId,
            employeeId: event.employeeId,
            employee: event,
        }
        
        var checkDuplicate = phase.phaseEmployee.findIndex( x => x.employeeId == newPhaseEmployee.employeeId && x.phaseId == newPhaseEmployee.phaseId);
        
        if(checkDuplicate == -1 ){
            phase.phaseEmployee.push(newPhaseEmployee);
            phase.successAddPerson = 'Thành công'
        }else{
            phase.successAddPerson = '';
            phase.errorAddPerson = 'Nhân viên đã có trong giai đoạn này';
        }
       
    }

    deletePersonHandle(phase, id) {

      
        this.modifiedPhase.listEmployeeDelete.push(id);
        phase.phaseEmployee.splice( phase.phaseEmployee.findIndex(x => x.phaseEmployeeId == id), 1)
    }



    deleteFieldHandle(phase, id) {

        this.modifiedPhase.listFieldDelete.push(id);
        phase.field.splice( phase.field.findIndex(x => x.fieldId == id), 1)
        console.log(this.modifiedPhase.listFieldDelete);
        
        
    }


     submitHandle(item) {
      //   console.log(this.modifiedPhase);
         
        this.saveAllState = true;
         
        if (item.description == '' || item.timeImplement == null) {
            this.saveAllState = false;
            return;
        }

            for(let i = 0; i < this.listPhase.length; i++){
                if(this.listPhase[i].description == '' || this.listPhase[i].timeImplement == null){ 
                    if(!this.listPhase[i].isLastPhase){
                        this.listPhase[i].active = true;     
                        this.listPhase[i].errorAddPhase = "Vui lòng điền đủ các trường" ;
                        this.saveAllState = false;           
                        return;
                    }  
                }
                delete this.listPhase[i].employeeValueInput;
                delete this.listPhase[i].errorAddField;
                delete this.listPhase[i].errorAddPerson;
                delete this.listPhase[i].errorAddPhase;
                delete this.listPhase[i].successAddField;
                delete this.listPhase[i].successAddPerson;

            }

            this.modifiedPhase.phase = this.process.phase;
            this.phaseService.updateMulti(this.modifiedPhase).subscribe(
                result => {
                    this.saveAllState = false;
                    this.router.navigateByUrl('manage-process/process/' + this.processId);
                },
                error => {
                    console.log(error);
                    
                }
            )
            
         
        
    }


    cancelHandle(event) {
        event.preventDefault();
        this.router.navigateByUrl('manage-process/process/' + this.processId)
    }

    deleteHandle(phase) {
      
        
        this.listPhase.forEach(x => {
            if (x.serial > phase.serial) {
                x.serial--;
                x.active = false;
            }
            if (x.serial == phase.serial) x.active = true;
        })
        if(phase.phaseId){
             this.modifiedPhase.listPhaseDelete.push(phase.phaseId);
        }
        this.listPhase.splice(this.listPhase.indexOf(phase),1);
    }

    addPhaseHandle(item, e) {
        e.preventDefault();
        var newPhase = this.createNewPhase(item.serial);

        this.listPhase.forEach(x => {
            if (x.serial >= newPhase.serial) {
                x.serial++;
                x.active = false;
            }

        })
        
        this.listPhase.push(newPhase);
        this.listPhase = this.listPhase.sort((x, y) => x.serial - y.serial);
      
    }

    // showValue() {
    //     console.log(this.optionForTime);

    // }

    resetError(phase){
        phase.errorAddPhase = '';
    }

    createNewPhase(serial){
        return {
            phaseId: uuidv4(),
            serial: serial + 1,
            name: 'Giai đoạn mới',
            description: '',
            posittion: 2,
            timeImplementType: '',
            timeImplement: null,
            employeeImplementType: 'all',
            employeeImplement: null,
            phaseEmployee:[],
            field: [],
            processRunning:[],
            processId: this.processId,
            active: true,
           
            employeeValueInput: '',
            errorAddPhase:'',
            errorAddPerson: '',
            errorAddField: '',
            successAddField: '',
            successAddPerson: '',
        }
    }
}
