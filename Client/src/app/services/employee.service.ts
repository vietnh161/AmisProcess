import { Injectable } from "@angular/core";
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Paging } from '../models/paging';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
    private ProcessUrl = 'api/employee';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
    ) { }

    getMulti(keyword: string): Observable<any> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}/getmulti/${keyword}`;
        return this.http.get<any>(url);
    }
    checkEmployeeExist(employee: any): Observable<any> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}/getSingleByCondition`;
        return this.http.post<any>(url,employee,this.httpOptions);
    }
}