import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { trigger } from '@angular/animations';
import { throwIfEmpty, isEmpty } from 'rxjs/operators';

import { AuthenticationService } from 'src/app/services';
import { PhaseService } from 'src/app/services/phase.service';

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

    optionForTime = 'h';
    optionForPerson;


    constructor(private route: ActivatedRoute, 
        private router: Router, 
        private authenticationService: AuthenticationService,
        private phaseService: PhaseService
         ) {
            this.processId = this.route.snapshot.paramMap.get("id");
            this.mode = this.route.snapshot.paramMap.get("mode");
            this.phaseSerial = parseInt(this.route.snapshot.paramMap.get("serial"));
            
    
    


        //     newPhase.serial = this.phaseSerial + 1;
        //     this.listPhase.push(newPhase);
        //     this.listPhase.forEach(x => {
        //         if (x.serial >= newPhase.serial && x.id != newPhase.id) {
        //             x.serial++;
        //             x.active = false;
        //         }
        //         if (x.serial <newPhase.serial) {
        //             x.active = false;
        //         }
        //         x.fieldTemp = {
        //             id: null,
        //             name: '',
        //             description: '',
        //             type: '',
        //             valueOption: '',
        //             options: [],
        //             required: false,
        //             pharseId: null,
        //         };
        //         x.employeeCodeTemp = null;
        //         x.errorAddPerson = '';
        //         x.errorAddField = '';
        //         x.successAddPerson = '';
        //         x.successAddField = '';
        //     })

        // } else {
        //     this.router.navigateByUrl('notfound');
        // }



 //       this.listPhase.sort((x, y) => x.serial - y.serial);
    
    }
test(e){
    console.log(this.listPhase);
    
}
    ngOnInit(): void {
        this.phaseService.getByProcessId(this.processId).subscribe(
            result => {
                this.listPhase = result;
                if(this.phaseSerial > this.listPhase.map(x=> x.serial).reduce((x,y) => Math.max(x,y)) ){
                  this.router.navigateByUrl('notfound');
                 }

                 if(this.mode == 'edit'){
                        this.listPhase.forEach(x => {
                            if (x.serial == this.phaseSerial) x.active = true;
                        });
                       
                        

                 }else if(this.mode == 'add'){

                    var newPhase = this.createNewPhase(this.phaseSerial);
                    console.log(this.phaseSerial);
                    
                       console.log(newPhase);
                       
                        this.listPhase.forEach(x => {
                                    if (x.serial >= newPhase.serial) {
                                        x.serial++;
                                        x.active = false;
                                    }
                                    if (x.serial <newPhase.serial) {
                                        x.active = false;
                                    }
                        
                                });
                        this.listPhase.push(newPhase);
                                
                 }else{
                    this.router.navigateByUrl('notfound');
                 }


                 this.listPhase.sort((x, y) => x.serial - y.serial);


            },
            error => {
                console.log(error);
                this.router.navigateByUrl('notfound');
            }
        )

    }

    // addPersonHandle(phase, event) {
    //     phase.errorAddPerson = '';
    //     phase.successAddPerson = ''
    //     if (event.keyCode == 13) {
    //         event.preventDefault();
    //         var employee = this.listEmployee.find(x => x.employeeCode == phase.employeeCode)
    //         if (employee != null) {
    //             phase.personImplement.push(employee);
    //             phase.employeeCode = '';
    //             phase.successAddPerson = 'Thành công'
    //         } else {
    //             phase.errorAddPerson = 'Nhân viên không tồn tại'
    //         }
    //     }

    // }

    // deletePersonHandle(phase, id) {

    //     var listPerson = this.phases.find(x => x.id == phase.id).personImplement;
    //     // console.log(listPerson);
    //     // console.log(this.phases.find(x=> x.id == phase.id).personImplement);
    //     //  console.log(id);

    //     listPerson.splice(listPerson.findIndex(x => x.id == id), 1)
    // }



    // deleteFieldHandle(phase, id) {
    //     // console.log(phase);
    //     // console.log(id);
    //     var listField = this.phases.find(x => x.id == phase.id).fields;
    //     listField.splice(listField.findIndex(x => x.id == id), 1)
    // }


     submitHandle() {
         console.log(this.listPhase);
         
    //     // console.log(item);
    //     if (item.description == '' || item.timeImplement == null) {
    //         return;
    //     }

    //         console.log(this.phases);
    //         for(let i = 0; i < this.phases.length; i++){
    //             if(this.phases[i].description == '' || this.phases[i].timeImplement == null){ 
    //                 this.phases[i].active = true;     
    //                 this.phases[i].errorAddPhase = "Vui lòng điền đủ các trường"            
    //                 return;
    //             }
    //         }

    //         phaseData.forEach(x => {
    //             if (x.processId == this.processId) {
    //                  phaseData.splice(phaseData.indexOf(x));
    //             }

    //         })

           
    //         this.phases.forEach(x => {
            
    //             delete x.active;
    //             delete x.fieldTemp;
    //             delete x.employeeCodeTemp;
    //             delete x.errorAddPerson;
    //             delete x.errorAddField;
    //             delete x.successAddPerson;
    //             delete x.successAddField;
    //             phaseData.push(x);
    //         })

    //         this.process.updatedTime = new Date();
    //         this.process.updatedBy = this.currentUser.firstName + ' ' + this.currentUser.lastName;
    //         //  console.log(phaseData);
    //         this.router.navigateByUrl('manage-process/process/' + this.processId);
        
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
            serial: serial + 1,
            name: 'Giai đoạn mới',
            description: '',
            timeImplementType: '',
            timeImplement: null,
            employeeImplementType: 'all',
            employeeImplement: [],
            field: [],
            processId: parseInt(this.processId),
            active: true,
            errorAddPhase:'',
            errorAddPerson: '',
            errorAddField: '',
            successAddField: '',
            successAddPerson: '',
        }
    }
}
