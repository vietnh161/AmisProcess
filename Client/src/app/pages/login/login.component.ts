import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/services';
import { error } from '@angular/compiler/src/util';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  getState: Observable<any>;
  submitted: boolean = false;
  returnUrl: string;
  errMessage: string;
 

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    //Nếu đã đăng nhập redirect sang path /
    if (this.authenticationService.currentUserValue) { 
      this.router.navigate(['/']);
  }

  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }


  get data() {
    return this.loginForm.controls;
  }


  onSubmit() {
    this.errMessage ='';
    this.submitted = true;
    
    if (this.loginForm.invalid) {
      this.submitted = false;
      return;
    }
    this.authenticationService.login(this.data.username.value, this.data.password.value).subscribe(
      result => {
        this.submitted = false;
        this.router.navigate([this.returnUrl]);
        
      },
      error => {
        this.errMessage ='Tên tài khoản hoặc mật khẩu không đúng!';
        this.submitted = false;
      }
    )
  
    
  }
}
