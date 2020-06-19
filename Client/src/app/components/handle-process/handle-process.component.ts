import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../_services';
import { listProcessData } from '../../data/list-process';
import { categoryData } from '../../data/category';
import { PhaseEmployee } from '../../_models/phase-employee';
import { phaseEmployeeData } from '../../data/phase-emloyee';

@Component({
  selector: 'app-handle-process',
  templateUrl: './handle-process.component.html',
  styleUrls: ['./handle-process.component.css']
})
export class HandleProcessComponent implements OnInit {

  currentUser;
  listProcessHandle;
  listCategory;

  canAddCategory = false;
  errorMessage: string;
  optionsForFilter = [
    {
      name: 'processName',
      title: 'Tên quy trình'
    },
    {
      name: 'createdBy',
      title: 'Người tạo'
    },
    {
      name: 'category',
      title: 'Danh mục'
    },
  ];

  optionsForSort = [
    {
      name: 'processName',
      title: 'Tên quy trình'
    },
    {
      name: 'createdBy',
      title: 'Người tạo'
    },
    {
      name: 'category',
      title: 'Danh mục'
    },
    {
      name: 'createdTime',
      title: 'Thời gian tạo'
    },
    {
      name: 'updatedTime',
      title: 'Chỉnh sửa mới nhất'
    },
  ];


  constructor(private route: ActivatedRoute, private authenticationService: AuthenticationService, private router: Router) {

    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.listProcessHandle = phaseEmployeeData.filter(x => x.employeeCode == this.currentUser.employeeCode);

    this.listCategory = categoryData;

    console.log(this.listProcessHandle);


  }

  ngOnInit(): void {
  }


  search(e) {

    // get from api at server
    console.log(e);

  }

  sort(e) {
    // get from api at server
    console.log(e);
  }

  handleProcess(id) {
    this.router.navigateByUrl('/handle-process/' + id);
  }

  getTimeRemaining(date) {

    var now = new Date();
    var createdTime = new Date(date);
    var timeRemaining = Math.ceil((now.getTime() - createdTime.getTime()) / (1000 * 3600 * 24))
    if (timeRemaining < 1) {
      timeRemaining = Math.ceil((now.getTime() - createdTime.getTime()) / (1000 * 3600))
      return timeRemaining;
    } else {
      return timeRemaining;
    }

  }

}
