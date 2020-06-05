import { Component, OnInit } from '@angular/core';
import {listProcessData} from '../../data/list-process'
import { phaseData } from '../../data/phase'
import {categoryData} from '../../data/category'
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';

@Component({
  selector: 'app-list-process',
  templateUrl: './list-process.component.html',
  styleUrls: ['./list-process.component.css'],
})
export class ListProcessComponent implements OnInit {

  currentUser;
  listProcess;
  listCategory;
  newProcess = {
    name: '',
    description:'',
    categoryId: null,
  };
  newCategory='';

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

  showFilterOption(){
  
  }

  onChangeStatus(item){
    console.log(item)
  }
  name(evt){

    console.log(evt)
  }

  test(item){
    console.log(item.isDel);
    
  }
}
