import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild } from '@angular/router';

import { AuthenticationService } from '../../app/services';
import { Store } from '@ngrx/store';
import { AppState, selectAuthState } from '../store/app.states';
import { Observable } from 'rxjs';
import { GetUserInfor } from '../store/actions/auth.actions';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    getState: Observable<any>;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
         private store : Store<AppState>,
    ) {
        
     }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        this.store.dispatch(new GetUserInfor({}));
        this.getState = this.store.select(selectAuthState);
        var currentUser;
        this.getState.subscribe(state => {  
            currentUser = state.user;
            if (currentUser) {

                
                if (route.data.role && route.data.role.indexOf(currentUser.role) === -1) {
                    // role not match will redirect to notfound page
                    this.router.navigate(['/notfound']);
                    return false;
                }
                console.log(currentUser);
                // authorised so return true
                return true;
            }
           
            console.log(currentUser);
            // not logged in so redirect to login page with the return url
            this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
            return false;
          })
         
          return true;
    //    const currentUser = this.authenticationService.currentUserValue;
      
    }

    // canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    //     const currentUser = this.authenticationService.currentUserValue;
    //     if(currentUser.role = )
    //     return false;
    // }
}