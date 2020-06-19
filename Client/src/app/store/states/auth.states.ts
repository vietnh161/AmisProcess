import { User } from 'src/app/_models';

export interface AuthState {
    isAuthenticated: boolean;
    user: User | null;
    errorMessage: string;
}