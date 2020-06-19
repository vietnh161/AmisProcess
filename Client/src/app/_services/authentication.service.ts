import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { User } from '../_models';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string): Observable<any> {
        var user = {
            username: username,
            password: password
        }
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
        return this.http.post<any>(`${environment.apiUrl}/account/authenticate`, user, httpOptions);
           
    }

    logout() {
        
        // localStorage.removeItem('currentUser');
        // this.currentUserSubject.next(null);
    }
}