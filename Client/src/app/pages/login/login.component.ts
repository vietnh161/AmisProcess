import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState, selectAuthState } from 'src/app/store/app.states';
import { Login } from 'src/app/store/actions/auth.actions';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  getState: Observable<any>;
  submitted: boolean = false;
  errMessage: string;
 

  constructor(
    private formBuilder: FormBuilder,
    private store: Store<AppState>
  ) {
    this.getState = this.store.select(selectAuthState);
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.getState.subscribe(state => {  
      this.errMessage = state.errorMessage;
      
      if(  this.errMessage != null){
        this.submitted = false;
      }
    })
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
    this.store.dispatch(new Login({username: this.data.username.value, password: this.data.password.value}));
  
    
  }
}
