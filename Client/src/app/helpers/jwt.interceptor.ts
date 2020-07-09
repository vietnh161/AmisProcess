import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { AuthenticationService } from '../services';
import { Store } from '@ngrx/store';
import { AppState, selectAuthState } from '../store/app.states';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    getState: Observable<any>;

    constructor(private authenticationService: AuthenticationService , private store: Store<AppState>) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add auth header with jwt if user is logged in and request is to api url
        this.getState = this.store.select(selectAuthState);
        var currentUser;
        this.getState.subscribe(state => {  
            currentUser = state.user;
        //    console.log(currentUser);
            
          })
      
        const token = localStorage.getItem('token');
        const isLoggedIn = currentUser && currentUser.token;
        const isApiUrl = request.url.startsWith(environment.apiUrl);
        if (token && isApiUrl) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${token}`
                }
            });
        }

        return next.handle(request);
    }
}