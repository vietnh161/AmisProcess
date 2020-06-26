// import * as auth from './reducers/auth.reducers';
import { User } from 'src/app/models';
import { AuthState } from './states/auth.states';
import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import  * as auth from './reducers/auth.reducers'

export interface AppState {
  authState: AuthState;
}


export const reducers = {
  auth: auth.reducer
};

export const selectAuthState = createFeatureSelector<AppState>('auth');