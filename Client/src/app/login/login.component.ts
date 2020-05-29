import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services';
import { Router } from '@angular/router';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  submitted: boolean = false;
  message: string

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {

  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }


  get data() {
    //console.log("test")
    return this.loginForm.controls;
  }


  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.authenticationService.login(this.data.username.value, this.data.password.value)
      .pipe(first())
      .subscribe(
        data => {
          
          this.router.navigateByUrl('home');
          // if(data.role == Role.Admin){
          //   this.router.navigateByUrl('admin');
          // }
          // else{
          //   this.router.navigateByUrl('employee');
          // }
        },
        error => {
          console.log(error)
          this.message = error.error.message;
        })
  }
}
