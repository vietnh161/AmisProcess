import { Component, OnInit } from '@angular/core';
import { User } from '../../models';
import { AuthenticationService } from '../../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  currentUser;
  isAdmin: boolean;
  getState: Observable<any>;
  sidebarLinks = [
    {
      name: 'Quản lý quy trình',
      path: 'manage-process',
      role: ['admin'],
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
      role: ['admin','employee'],
      icon:'play'
    },
    {
      name: 'Quy trình cần xử lý',
      path: '/handle-process',
      role: ['admin','employee'],
      icon:'pencil'
    },
    {
      name: 'Quy trình đã xử lý',
      path: '/done-process',
      role: ['admin','employee'],
      icon:'check'
    }, 
  ]

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.authenticationService.getUserLogged();
    
  }

  logOut() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);

  }
  test(){
    this.authenticationService.getUserLogged();
  }
}
