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
  newCategory;
  errorMessage:string;
  optionFilterSelected:string = 'name';
  optionSortBySelected:string = 'updatedTime';
  constructor(private route:ActivatedRoute, private authenticationService: AuthenticationService ,private router: Router) { 
   
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.listProcess = listProcessData;
    this.listCategory = categoryData;

  }

  ngOnInit(): void {
  }

  addProcessHandle(){
    if(this.newProcess.name == '' || this.newProcess.description == ''){
        this.errorMessage = "Tên quy trình hoặc mô tả không được để trống";
        return;
    }else{
       if(this.newProcess.categoryId == ''){
          if(this.newCategory == ''){
            this.errorMessage = "Danh mục không được để trống"
            return;
          }else{
            var newCtg = {
              id: 1 + this.listCategory.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
              name : this.newCategory
            }
            this.listCategory.push(newCtg);
            this.newProcess.categoryId = newCtg.id;
            console.log(this.newProcess);
          }
       }
      }
    var item = {
      id: 1 + this.listProcess.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
      name: this.newProcess.name,
      createdBy: this.currentUser.firstName + ' ' + this.currentUser.lastName,
      createdTime: new Date().toISOString(),
      updatedTime: new Date().toISOString(),
      updatedBy: this.currentUser.firstName + ' ' + this.currentUser.lastName,
      status: 'Đang hoạt động',
      categoryId: this.newProcess.categoryId,
      category: this.listCategory.find(x => x.id == this.newProcess.categoryId)
     }
     console.log(item);
     this.listProcess.push(item);

     
     var newPharse = [
       {
      id: 1 + phaseData.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
      serial: 1,
      name: 'Khởi tạo',
      description: '',
      timeImplementType:'',
      timeImplement: null,
      personImplementType:'all',
      personImplement: [],
      fields:[],
      processId: item.id,
     },
     {
      id: 1 + phaseData.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
      serial: 2,
      name: 'Hoàn thành',
      description: '',
      timeImplementType:'h',
        timeImplement: null,
        personImplementType:'all',
      personImplement: [],
      fields:[],
      processId: item.id,
     },
    ]
     phaseData.push(newPharse[0])
     phaseData.push(newPharse[1])


     this.router.navigateByUrl("manage-process/process/" + item.id )
   
  }



  showFilterOption(){
    console.log(this.optionFilterSelected)
  }

  showSortByOption(){
    console.log(this.optionSortBySelected)
  }
  onChangeStatus(item){
    console.log(item)
  }
  name(evt){

    console.log(evt)
  }
}
