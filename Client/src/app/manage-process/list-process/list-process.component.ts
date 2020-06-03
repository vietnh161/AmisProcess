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
  optionFilterSelected:string = 'name';
  optionSortBySelected:string = 'updatedTime';


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

  addProcessHandle(){
 //   console.log(this.newCategory);
    
    if(this.newProcess.name == '' || this.newProcess.description == ''){
        this.errorMessage = "Tên quy trình hoặc mô tả không được để trống";
        return;
    }else{
       if(this.newProcess.categoryId == null || this.canAddCategory){
          if(this.newCategory == ''){
            this.errorMessage = "Danh mục không được để trống"
            return;
          }else{
            this.newProcess.categoryId == null

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
      status: 'maintain',
      categoryId: this.newProcess.categoryId,
      category: this.listCategory.find(x => x.id == this.newProcess.categoryId)
     }

     this.listProcess.push(item);

     
     var newPhase = [
       {
      id: 1 + phaseData.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
      serial: 1,
      name: 'Khởi tạo',
      description: '',
      canDel:false,
      isLastPhase:false,
      timeImplementType:'',
      timeImplement: null,
      personImplementType:'all',
      personImplement: [],
      fields:[],
      processId: item.id,
     },
     {
      id: 2 + phaseData.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
      serial: 2,
      name: 'Hoàn thành',
      description: '',
      timeImplementType:'',
      canDel:false,
      isLastPhase:true,
        timeImplement: null,
        personImplementType:'all',
      personImplement: [],
      fields:[],
      processId: item.id,
     },
    ]
     phaseData.push(newPhase[0])
     phaseData.push(newPhase[1])


     this.router.navigateByUrl("manage-process/process/" + item.id )
   
  }

  deleteProcess(process){
    this.listProcess.splice(this.listProcess.findIndex(x=> x.id == process.id),1)
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

  test(item){
    console.log(item.isDel);
    
  }
}
