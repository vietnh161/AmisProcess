import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';
import { listProcessData } from 'src/app/data/list-process';
import { phaseData } from 'src/app/data/phase';
import { phaseEmployeeData } from 'src/app/data/phase-emloyee';
import { fieldEmployeeData } from 'src/app/data/field-employee';
import { PhaseEmployee } from 'src/app/_models/phase-employee';
import { Items } from '@clr/angular/data/datagrid/providers/items';

@Component({
  selector: 'app-detail-run',
  templateUrl: './detail-run.component.html',
  styleUrls: ['./detail-run.component.css']
})
export class DetailRunComponent implements OnInit {
  currentUser;
 
  process;
  phase;
  nextPhase;
  fields;
  phase_employee;
  field_employee;
  assignee;


  constructor(private route:ActivatedRoute, private authenticationService: AuthenticationService ,private router: Router) { 
   
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    var processId  =  parseInt(this.route.snapshot.paramMap.get("id"));

    // this.phase_employee = phaseEmployeeData.find(x=> x.id == phaseEmployeeId);
    // this.field_employee = fieldEmployeeData.filter(x=> x.phaseEmployeeId == phaseEmployeeId);

    this.process = listProcessData.find(x=> x.id == processId);
    
 
  // console.log(phaseEmployeeData);
    if(  this.process   == null){
      router.navigateByUrl('/notfound')
    }


   
    this.phase = phaseData.find(x=> x.processId == processId && x.serial == 1);
    console.log(  this.field_employee);


    this.phase.fields.forEach(e => {
      e.value ='';
      e.valueForCheckBox=[];
    });
    // this.fields = this.phase.map(x => x.field)

    this.nextPhase = phaseData.find(x=> x.serial == this.phase.serial+1);
    
  }

  ngOnInit(): void {
      
  }

  submitHandle(){
    console.log(this.phase);
    
    //  console.log(this.field_employee);
    var newItem1: PhaseEmployee = {
      id : (phaseEmployeeData.length > 0)? 1+  phaseEmployeeData.map(x => x.id).reduce((x,y) => Math.max(x,y)): 1,
      employeeCode: this.currentUser.employeeCode,
      phaseId: this.phase.id,
      createdBy: this.currentUser.firstName + ' ' + this.currentUser.lastName ,
      createdTime: new Date().toString(),
      updatedTime: new Date().toString(),
      updatedBy: this.currentUser.firstName + ' ' + this.currentUser.lastName ,
      phase: this.phase
    }
    phaseEmployeeData.push(newItem1)

    var newItem: PhaseEmployee = {
      id : 1+  phaseEmployeeData.map(x => x.id).reduce((x,y) => Math.max(x,y)),
      employeeCode: this.assignee,
      phaseId: this.nextPhase.id,
      createdBy: this.currentUser.firstName + ' ' + this.currentUser.lastName ,
      createdTime: new Date().toString(),
      updatedTime: new Date().toString(),
      updatedBy: this.currentUser.firstName + ' ' + this.currentUser.lastName ,
      phase: this.nextPhase
    }

    phaseEmployeeData.push(newItem);
    
    this.phase.fields.forEach(e => {
      var newField =  {
        id: (fieldEmployeeData.length > 0)? 1+  fieldEmployeeData.map(x => x.id).reduce((x,y) => Math.max(x,y)): 1,
        fieldId: e.id,
        field: e,
        phaseEmployeeId: newItem1.id,
        value: e.value,
        valueForCheckBox: e.valueForCheckBox
  
    }
      fieldEmployeeData.push(newField)
      
    });
  

    fieldEmployeeData.push()

      console.log(phaseEmployeeData);
  }
  setValueCheckBox(item, optionId,e){


    if(e.checked){
      item.valueForCheckBox.push(optionId) ;

 //     console.log( 'push');
    }else{
    
       item.valueForCheckBox.splice(item.valueForCheckBox.indexOf(optionId),1);
   //   console.log( 'pop');
      
    }
    console.log(item.valueForCheckBox);
    
  }

}
