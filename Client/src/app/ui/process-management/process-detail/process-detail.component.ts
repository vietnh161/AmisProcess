import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { ProcessService } from 'src/app/services/process.service';
import { Process } from 'src/app/models';
import { PhaseService } from 'src/app/services/phase.service';

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
    deletePhaseState: boolean;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private processService: ProcessService,
        private phaseService: PhaseService,
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
        this.deletePhaseState = true;
        this.phaseService.deleteById(phase.phaseId).subscribe(
            result => {
                this.deletePhaseState = false;
                this.router.navigateByUrl('/manage-process/list-process', { skipLocationChange: true }).then(() => {
                    this.router.navigateByUrl("manage-process/process/" + result)
                }); 
            },
            error => {
                this.router.navigateByUrl('notfound');
            }
        )
    }
}
