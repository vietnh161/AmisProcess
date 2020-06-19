import { User } from 'src/app/_models';
import { AuthState } from '../states/auth.states';
import { All, AuthActionTypes } from '../actions/auth.actions';


export const initialState: AuthState = {
    isAuthenticated: false,
    user: null,
    errorMessage: null
}

export function reducer(state = initialState, action: All): AuthState {
    switch (action.type) {
      case AuthActionTypes.LOGIN_SUCCESS: {
        return {
          ...state,
          isAuthenticated: true,
          user: {
            token: action.payload.token,
            username: action.payload.username,
            role: action.payload.role,
            id: action.payload.id
          },
          errorMessage: ''
        };
      }
      case AuthActionTypes.LOGIN_FAIL: {
        return {
          ...state,
          errorMessage: 'Tài khoản hoặc mật khẩu không đúng'
        };
      }
      case AuthActionTypes.LOGOUT: {
        return initialState;
      }
      default: {
        return state;
      }
    }
  }