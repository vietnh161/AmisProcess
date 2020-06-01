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
    constructor(private route: ActivatedRoute,private router: Router) {
        this.processId =  this.route.snapshot.paramMap.get("id");
        this.process = listProcessData.find(x=> x.id == this.processId);
        if(this.process == null ){
            this.router.navigateByUrl('notfound');
        }
        this.phases = phaseData.filter(x => x.processId == this.processId).sort((x,y) => x.serial - y.serial)
        console.log(this.process);
        
    }

    ngOnInit(): void {
        
    }

}
