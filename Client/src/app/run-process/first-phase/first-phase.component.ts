import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';
import { listProcessData } from 'src/app/data/list-process';
import { categoryData } from 'src/app/data/category';
import { phaseData } from 'src/app/data/phase';

@Component({
  selector: 'app-first-phase',
  templateUrl: './first-phase.component.html',
  styleUrls: ['./first-phase.component.css']
})
export class FirstPhaseComponent implements OnInit {
  currentUser;
  listProcess;
  listPhase;
  process;
  phase;
  fields;

  constructor(private route:ActivatedRoute, private authenticationService: AuthenticationService ,private router: Router) { 
   
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    var id  =  this.route.snapshot.paramMap.get("id");

    this.listProcess = listProcessData;
    this.listPhase = phaseData;
    
    this.process = this.listProcess.find(x=> x.id == id);
    this.phase = this.listPhase.find(x=> x.processId == id && x.serial == 1)
  }

  ngOnInit(): void {
      console.log(this.phase.fields);
      
  }

  submitHandle(){
     this.phase.fields.forEach(f => {
         if(f.type == 'Check Box'){
            f.options.forEach(o => {
                if(o.selected){
                    f.valueForCheckBox.push(o.id.toString())
                }
            });
         }
      
     });

      console.log(this.phase.fields);
      
  }

  test(a,b){
      if(!a.selected){
        b.value+= a.id.toString() +';'
        a.selected = true
      } else{
        b.value =  (a.id.toString() +';')
        a.selected = false
      }
     
      console.log( b.value);
      
  }
}
