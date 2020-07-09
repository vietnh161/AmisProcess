import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { tap, catchError, map } from 'rxjs/operators';
import { Process } from '../models';
import { environment } from 'src/environments/environment';
import { Paging } from '../models/paging';


@Injectable({ providedIn: 'root' })
export class ProcessService {

    private ProcessUrl = 'api/process';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
    ) { }

    /** Lấy tất cả bản ghi của process */
    getAll(): Observable<Process[]> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}`;
        return this.http.get<Process[]>(url)
    }

    /** Lây process theo id */
    getById(id: number): Observable<Process> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}/${id}`;
        return this.http.get<Process>(url);
    }

     /** Lây process theo id bao gom field option employee */
     getIncludeById(id: number): Observable<Process> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}/includeField/${id}`;
        return this.http.get<Process>(url);
    }

    /** Phân trang */
    getMultiPaging(paging: Paging): Observable<any> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}/page`;
        return this.http.post<any>(url,paging, this.httpOptions);
    }

    // Tạo mới Process
    addProcess(process: Process): Observable<any>{
        const url = `${environment.apiUrl}/${this.ProcessUrl}`;
        return this.http.post<Process>(url,process,this.httpOptions);
    }

    // Cập nhật Process
    updateProcess(process: Process): Observable<any>{
        const url = `${environment.apiUrl}/${this.ProcessUrl}`;
        return this.http.put<Process>(url,process,this.httpOptions);
    }

    handleError(error) {
        console.log(error.error);
        
        
        return throwError(error);
    }

    /** Log a ProcessService message with the MessageService */
    // private log(message: string) {
    //     this.messageService.add(`ProcessService: ${message}`);
    // }
}