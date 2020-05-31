import { Component, OnInit } from '@angular/core';
import { listProcessData } from '../../data/list-process'
import { categoryData } from '../../data/category'
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-detail-process',
    templateUrl: './detail-process.component.html',
    styleUrls: ['./detail-process.component.css'],
})
export class DetailProcessComponent implements OnInit {

    processId;
    process;
    constructor(private route: ActivatedRoute) {

    }

    ngOnInit(): void {
        this.processId =  this.route.snapshot.paramMap.get("id");
            this.process = listProcessData.find(x=> x.id = this.processId);
            console.log(this.process);
            
    }

}
