import { User } from 'src/app/models';

export interface AuthState {
    isAuthenticated: boolean;
    user: User | null;
    errorMessage: string;
}