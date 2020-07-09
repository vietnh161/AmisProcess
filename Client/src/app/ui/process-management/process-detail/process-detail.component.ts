import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { ProcessService } from 'src/app/services/process.service';
import { Process } from 'src/app/models';

@Component({
    selector: 'app-process-detail',
    templateUrl: './process-detail.component.html',
    styleUrls: ['./process-detail.component.css'],
})
export class ProcessDetailComponent implements OnInit {

    processId;
    process : Process;
    phases;
    currentProcessStatus;
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private processService: ProcessService,
        ) {
        this.processId =  this.route.snapshot.paramMap.get("id");
        
    }

    ngOnInit(): void {
        this.processService.getById(this.processId).subscribe(
            result => {
                console.log(result);
                this.process = result;
                this.phases = this.process.phase;
                this.phases.sort((x,y) => x.serial - y.serial);
                console.log(this.phases);
                
            },
            error => {
                console.log(error);
               
                    this.router.navigateByUrl('notfound');
                
            }
        )
        
    }

    changeStatus(ok){
     
    }

    deletePhaseHandle(phase){

    }
}
