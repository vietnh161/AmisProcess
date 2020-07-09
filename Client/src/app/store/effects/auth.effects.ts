import { Injectable } from '@angular/core';
import { Action } from '@ngrx/store';
import { Router } from '@angular/router';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Observable, of } from 'rxjs';
import { tap, map, switchMap, catchError } from 'rxjs/operators';

import { AuthenticationService } from 'src/app/services';
import { AuthActionTypes, Login, LoginSuccess, LoginFail, GetUserInfor, GetUserSuccess } from '../actions/auth.actions';
import { User } from 'src/app/models';


@Injectable()
export class AuthEffects {

    constructor(
        private actions: Actions,
        private authService: AuthenticationService,
        private router: Router,
    ) { }

    // effects go here
    @Effect()
    GetUserInfor: Observable<Action> = this.actions.pipe(
        ofType(AuthActionTypes.GET_CURRENT_USER),
        map((action: GetUserInfor) => action.payload),
        switchMap(payload => {
            return this.authService.getUserLogged()
                .pipe(
                    map((user) => {


                        return new GetUserSuccess({ token: user.token, username: user.userName, fullName: user.fullName });
                    }),

                    catchError(err => {
                        console.log(err);
                        return of(new LoginFail({ error: err }));
                    })
                )

        }));

    @Effect()
    Login: Observable<Action> = this.actions.pipe(
        ofType(AuthActionTypes.LOGIN),
        map((action: Login) => action.payload),
        switchMap(payload => {
            return this.authService.login(payload.username, payload.password)
                .pipe(
                    map((user) => {


                        return new LoginSuccess({ token: user.token, username: payload.username, fullName: user.fullName });
                    }),

                    catchError(err => {
                        console.log(err);
                        return of(new LoginFail({ error: err }));
                    })
                )

        }));

    @Effect({ dispatch: false })
    GetUserSuccess: Observable<any> = this.actions.pipe(
        ofType(AuthActionTypes.GET_USER_SUCCESS),
        tap((user) => {
            localStorage.setItem('token', user.payload.token);
        })
    );

    @Effect({ dispatch: false })
    LoginSuccess: Observable<any> = this.actions.pipe(
        ofType(AuthActionTypes.LOGIN_SUCCESS),
        tap((user) => {
            localStorage.setItem('token', user.payload.token);
            this.router.navigateByUrl('/');
        })
    );

    @Effect({ dispatch: false })
    public LogOut: Observable<any> = this.actions.pipe(
        ofType(AuthActionTypes.LOGOUT),
        tap((user) => {
            localStorage.removeItem('token');
            this.router.navigateByUrl('/login');
        })
    );
}

