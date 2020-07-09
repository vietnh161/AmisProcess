import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services';
import { ClrDatagridStateInterface } from '@clr/angular';
import { ProcessService } from 'src/app/services/process.service';
import { Paging } from 'src/app/models/paging';
import { tap, map } from 'rxjs/operators';

@Component({
  selector: 'app-process-list',
  templateUrl: './process-list.component.html',
  styleUrls: ['./process-list.component.css'],
})
export class ProcessListComponent implements OnInit {

  currentUser;
  listProcess;
  listCategory;

  canAddCategory = false;
  errorMessage: string;

  total: number;
  loading: boolean = true;
  paging: Paging;


  constructor(
    private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
    private router: Router,
    private processService: ProcessService,
    private cdr: ChangeDetectorRef
  ) {

    this.paging = {
      currentPage: 1,
      pageSize: 10,
      sort: 'DESC',
      sortBy: 'createdAt',
      filters:null,
    }


    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
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
          this.cdr.detectChanges();
          return;
        },
        err => console.log(err)
      )

  }
  deleteProcess(process) {
    this.listProcess.splice(this.listProcess.findIndex(x => x.id == process.id), 1)
  }

  search(e) {

    // get from api at server
    console.log(e);

  }

  sort(e) {
    // get from api at server
    console.log(e);
  }

}
