import { Component, OnInit } from '@angular/core';
import { User } from '../../_models';
import { AuthenticationService } from '../../_services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AppState, selectAuthState } from 'src/app/store/app.states';
import { Store } from '@ngrx/store';
import { LogOut } from 'src/app/store/actions/auth.actions';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-main-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class MainLayoutComponent implements OnInit {

  currentUser;
  isAdmin: boolean;
  getState: Observable<any>;
  sidebarLinks = [
    {
      name: 'Quản lý quy trình',
      path: 'manage-process',
      role: 'admin',
      icon:'certificate',
      childs: [
        {
          name: 'Danh sách quy trình',
          path: '/list-process',
        },
        {
          name: 'Xem hoạt động quy trình',
          path: '/process-activity',
        },
      ]
    },
    {
      name: 'Chạy quy trình',
      path: '/run-process',
      role: 'user',
      icon:'play'
    },
    {
      name: 'Quy trình cần xử lý',
      path: '/handle-process',
      role: 'user',
      icon:'pencil'
    },
    {
      name: 'Quy trình đã xử lý',
      path: '/done-process',
      role: 'user',
      icon:'check'
    }, 
  ]

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    private store: Store<AppState>,
  ) {
    this.getState = this.store.select(selectAuthState);
  
    // this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    // if (this.currentUser.role == 'Admin') {
    //   this.isAdmin = true;
    // } else {
    //   this.isAdmin = false;
    // }
    // console.log(this.currentUser)
  }

  ngOnInit() {
    this.getState.subscribe(state => {  
      this.currentUser = state.user;
      console.log(this.currentUser);
      
      if (this.currentUser.role == 'Admin') {
        this.isAdmin = true;
      } else {
        this.isAdmin = false;
      }
    })
  }

  logOut() {
  
    this.store.dispatch(new LogOut())

  }
}
