import { Component, OnInit } from '@angular/core';
import { listProcessData } from '../../data/list-process'
import { phaseData } from '../../data/phase'
import { categoryData } from '../../data/category'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-detail-process',
    templateUrl: './detail-process.component.html',
    styleUrls: ['./detail-process.component.css'],
})
export class DetailProcessComponent implements OnInit {

    processId;
    process;
    phases;
    currentProcessStatus;
    constructor(private route: ActivatedRoute,private router: Router) {
        this.processId =  this.route.snapshot.paramMap.get("id");
        this.process = listProcessData.find(x=> x.id == this.processId);
        this.currentProcessStatus = this.process.status;

        if(this.process == null ){
            this.router.navigateByUrl('notfound');
        }
        // this.phases = phaseData.filter(x => x.processId == this.processId).sort((x,y) => x.serial - y.serial)
        
    }

    ngOnInit(): void {
        
        
       
        
        this.phases = phaseData.filter(x => x.processId == this.processId).sort((x,y) => x.serial - y.serial);
        this.phases.forEach(element => {
            element.isDel = false;
        });
        
    }

    changeStatus(ok){
        
        if(ok){
            
            this.process.updatedTime= new Date();
          //  this.process.updatedBy = 



        }else{
             this.currentProcessStatus = this.process.status ; 
        }
       
    }

    deletePhaseHandle(phase){

       
        phaseData.splice(phaseData.findIndex(x=> x.id == phase.id),1)
     
        this.phases = phaseData.filter(x => x.processId == this.processId).sort((x,y) => x.serial - y.serial);
    }
}
