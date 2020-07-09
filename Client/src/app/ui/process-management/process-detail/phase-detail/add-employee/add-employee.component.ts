import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, Input, Output ,EventEmitter} from '@angular/core';
import { fromEvent } from 'rxjs';
import { map, filter, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit, AfterViewInit {

  @Input() phase;
  @Output() addEmployee = new EventEmitter();

  listEmployee;
  listEmployeeImplement;
  @ViewChild("employeeInput") employeeInput: ElementRef;


  constructor(
    private employeeService: EmployeeService
  ) { }

  ngOnInit(): void {
  }
  ngAfterViewInit(): void {

    fromEvent(this.employeeInput.nativeElement, 'keyup').pipe(
      map((event: any) => event.target.value),
      filter(x => x.length >= 3),     // value có ít nhất 3 kí tự
      debounceTime(1000),             // Event sẽ thực hiện sau sau khi ngừng gõ 1s
      distinctUntilChanged(),         // kiểm tra giá trị nếu có sự thay đổi thì event mới được thực hiên
    ).subscribe(
      value => {

        this.employeeService.getMulti(value).subscribe(
          result => {

            this.listEmployee = result;
          },
          error => {
            console.log(error);

          }
        )
      }
    );
  }
  emitEmployee(e) {
    this.phase.successAddPerson = '';
    this.phase.errorAddPerson = ''
    var employeeString = e.target.value;
     var i = employeeString.indexOf('-');
     if(i == -1){
      
       return;
     }
     var employee = {
       employeeCode: employeeString.slice(i+2, employeeString.length),
       fullName: employeeString.slice(0,i-1),
     }
     this.employeeService.checkEmployeeExist(employee).subscribe(
       result => {
          if(result != null){
            this.addEmployee.emit(result);
           
          }else{
             this.phase.errorAddPerson = 'Nhân viên không tồn tại'
          }
       },
     )
  }
}
