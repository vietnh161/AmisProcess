import { Component, OnInit } from '@angular/core';
import {listProcessData} from '../../data/list-process'
import {categoryData} from '../../data/category'
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-process',
  templateUrl: './list-process.component.html',
  styleUrls: ['./list-process.component.css'],
})
export class ListProcessComponent implements OnInit {

  listProcess;
  listCategory;
  newProcess = {
    name: '',
    description:'',
    categoryId:''
  };
  newCategory;
  errorMessage:string;
  optionFilterSelected:string = 'name';
  optionSortBySelected:string = 'updatedTime';
  constructor(private route:ActivatedRoute) { 
    this.listProcess = listProcessData;
    this.listCategory = categoryData;

  }

  ngOnInit(): void {
  }

  addProcessHandle(){
    if(this.newProcess.name == '' || this.newProcess.description == ''){
        this.errorMessage = "Tên quy trình hoặc mô tả không được để trống"
    }else{
       if(this.newProcess.categoryId == ''){
          if(this.newCategory == ''){
            this.errorMessage = "Danh mục không được để trống"
          }else{
            var newCtg = {
              id: this.listCategory.map(x=> x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
              name : this.newCategory
            }
            this.listCategory.push(newCtg);
            this.newProcess.categoryId = newCtg.id;
            console.log(this.newProcess);
          }
       }else{
         console.log(this.newProcess);
         
       }
    }
   
    
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
