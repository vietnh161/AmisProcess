import { Action } from '@ngrx/store';


export enum AuthActionTypes {
    LOGIN = '[Auth] Login',
    LOGIN_SUCCESS = '[Auth] Login Success',
    LOGIN_FAIL = '[Auth] Login Fail',
    LOGOUT = '[Auth] Logout',
}

export class Login implements Action {
    readonly type = AuthActionTypes.LOGIN;
    constructor(public payload: any) { }
}

export class LoginSuccess implements Action {
    readonly type = AuthActionTypes.LOGIN_SUCCESS;
    constructor(public payload: any) { }
}

export class LoginFail implements Action {
    readonly type = AuthActionTypes.LOGIN_FAIL;
    constructor(public payload: any) { }
}

export class LogOut implements Action {
    readonly type = AuthActionTypes.LOGOUT;
}

export type All = Login | LoginSuccess | LoginFail | LogOut;