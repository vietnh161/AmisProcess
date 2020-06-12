import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';
import { listProcessData } from 'src/app/data/list-process';
import { phaseData } from 'src/app/data/phase';
import { phaseEmployeeData } from 'src/app/data/phase-emloyee';
import { fieldEmployeeData } from 'src/app/data/field-employee';

@Component({
  selector: 'app-detail-handle',
  templateUrl: './detail-handle.component.html',
  styleUrls: ['./detail-handle.component.css']
})
export class DetailHandleComponent implements OnInit {
  currentUser;
 
  process;
  phase;
  nextPhase;
  fields;
  phase_employee;
  field_employee;


  constructor(private route:ActivatedRoute, private authenticationService: AuthenticationService ,private router: Router) { 
   
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    var phaseEmployeeId  =  parseInt(this.route.snapshot.paramMap.get("id"));

    this.phase_employee = phaseEmployeeData.find(x=> x.id == phaseEmployeeId);
    this.field_employee = fieldEmployeeData.filter(x=> x.phaseEmployeeId == phaseEmployeeId);

    this.process = listProcessData.find(x=> x.id == phaseEmployeeId);
   this.fields = this.field_employee.map(x => x.field)
 
 //  console.log(  this.fields);
   
   
    this.phase = phaseData.find(x=> x.id == this.phase_employee.phaseId);

    this.nextPhase = phaseData.find(x=> x.serial == this.phase.serial+1);
    
  }

  ngOnInit(): void {
   //   console.log(this.field_employee);
      
  }

  submitHandle(){

    //  console.log(this.field_employee);

    // phaseEmployeeData.push(
    //     {
    //       id : 1+  phaseEmployeeData.map(x => x.id).reduce((x,y) => Math.max(x,y)),
    //       employeeCode: this.field_employee.find(x => x.field.type == "Asignee Select").value,
    //       phaseId: this.nextPhase.id,
    //       createdBy:this.currentUser.firstName + ' ' +this.currentUser.lastName,
    //       createdTime: new Date().toString(),
    //       updatedTime: new Date().toString(),
    //       updatedBy: this.currentUser.firstName + ' ' +this.currentUser.lastName,
    //     }
    //   )
      console.log(phaseEmployeeData);
  }
  setValueCheckBox(item, optionId,e){

   
    console.log(optionId);
    if(e.checked){
      item.valueForCheckBox.push(optionId);
 //     console.log( 'push');
    }else{
      item.valueForCheckBox.splice(item.valueForCheckBox.indexOf(optionId),1);
   //   console.log( 'pop');
      
    }
    console.log(item.valueForCheckBox);
    
  }

}
