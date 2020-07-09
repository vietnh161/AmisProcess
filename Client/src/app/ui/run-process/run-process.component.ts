import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services';
import { ProcessService } from 'src/app/services/process.service';
import { Paging } from 'src/app/models/paging';
import { ClrDatagridStateInterface } from '@clr/angular';


@Component({
  selector: 'app-run-process',
  templateUrl: './run-process.component.html',
  styleUrls: ['./run-process.component.css']
})
export class RunProcessComponent implements OnInit {

  currentUser;
  listProcess;
  
  errorMessage:string;

  total: number;
  loading: boolean = true;
  paging: Paging;

  constructor(private route:ActivatedRoute,private processService: ProcessService,  private authenticationService: AuthenticationService ,private router: Router) { 
   
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    this.paging = {
      currentPage: 1,
      pageSize: 10,
      sort: 'DESC',
      sortBy: 'createdAt',
      filters:null,
    }
    
  }

  ngOnInit(): void {
    

  }
  refresh(state: ClrDatagridStateInterface) {
    this.loading = true;
    var newPaging: Paging = {
      currentPage: state.page.current,
      pageSize: state.page.size,
      filters: state.filters,
      sort: (state.sort && state.sort.reverse)? 'ASC': 'DESC',
      sortBy:  (state.sort && state.sort.by)? state.sort.by.toString(): 'createdAt',
    }
    this.processService.getMultiPaging(newPaging)
    .subscribe(
        result => {
          this.listProcess = result.data;
          this.total = result.totalRow;
          this.loading = false;
          return;
        },
        err => console.log(err)
      )

  }

  deleteProcess(process){
    this.listProcess.splice(this.listProcess.findIndex(x=> x.id == process.id),1)
  }


  runProcess(item){
    if(item.status == 'active')
    this.router.navigateByUrl('/run-process/'+ item.id);
  }

}
