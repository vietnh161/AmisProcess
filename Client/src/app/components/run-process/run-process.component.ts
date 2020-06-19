import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';
import { listProcessData } from 'src/app/data/list-process';
import { categoryData } from 'src/app/data/category';


@Component({
  selector: 'app-run-process',
  templateUrl: './run-process.component.html',
  styleUrls: ['./run-process.component.css']
})
export class RunProcessComponent implements OnInit {

  currentUser;
  listProcess;
  listCategory;

  canAddCategory=false;
  errorMessage:string;
  optionsForFilter= [
    {
      name: 'processName',
      title:'Tên quy trình'
    },
    {
      name: 'createdBy',
      title:'Người tạo'
    },
    {
      name: 'category',
      title:'Danh mục'
    },
  ];
  
  optionsForSort = [
    {
      name: 'processName',
      title:'Tên quy trình'
    },
    {
      name: 'createdBy',
      title:'Người tạo'
    },
    {
      name: 'category',
      title:'Danh mục'
    },
    {
      name: 'createdTime',
      title:'Thời gian tạo'
    },
    {
      name: 'updatedTime',
      title:'Chỉnh sửa mới nhất'
    },
  ];


  constructor(private route:ActivatedRoute, private authenticationService: AuthenticationService ,private router: Router) { 
   
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.listProcess = listProcessData;
    this.listCategory = categoryData;
    
    this.listProcess.forEach(element => {
      element.isDel = false;
    });
    
  }

  ngOnInit(): void {
  }


  deleteProcess(process){
    this.listProcess.splice(this.listProcess.findIndex(x=> x.id == process.id),1)
  }

  search(e){

    // get from api at server
    console.log(e);
    
  }

  sort(e){
 // get from api at server
    console.log(e);
  }

  runProcess(item){
    if(item.status == 'active')
    this.router.navigateByUrl('/run-process/'+ item.id);
  }

}
