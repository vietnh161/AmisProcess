import { Component, OnInit } from '@angular/core';
import { User } from '../_models';
import { AuthenticationService } from '../_services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class MainLayoutComponent implements OnInit {

  currentUser: User
  isAdmin: boolean;
  sidebarLinks = [
    {
      name: 'Quản lý quy trình',
      path: 'manage-process',
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
    },
    {
      name: 'Quy trình cần xử lý',
      path: '/handle-process',
    },
    {
      name: 'Quy trình đã xử lý',
      path: '/done-process',
    }, 
  ]

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    if (this.currentUser.role == 'Admin') {
      this.isAdmin = true;
    } else {
      this.isAdmin = false;
    }
    // console.log(this.currentUser)
  }

  ngOnInit() {
  }

  logOut() {
    //  console.log("a")
    this.authenticationService.logout();
    this.router.navigateByUrl('/login');
  }
}
