import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { tap, catchError, map } from 'rxjs/operators';
import { Phase } from '../models';
import { environment } from 'src/environments/environment';
import { Paging } from '../models/paging';


@Injectable({ providedIn: 'root' })
export class PhaseService {

    private PhaseUrl = 'api/phase';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
    ) { }

    /** Lấy tất cả bản ghi của Phase */
    getAll(): Observable<Phase[]> {
        const url = `${environment.apiUrl}/${this.PhaseUrl}`;
        return this.http.get<Phase[]>(url)
    }

    /** Lây Phase theo id */
    getById(id: number): Observable<Phase> {
        const url = `${environment.apiUrl}/${this.PhaseUrl}/${id}`;
        return this.http.get<Phase>(url);
    }

     /** Lây Phase theo processId */
    getByProcessId(id: number): Observable<Phase> {
        const url = `${environment.apiUrl}/${this.PhaseUrl}/getbyprocess/${id}`;
        return this.http.get<Phase>(url);
    }

    /** Phân trang */
    getMultiPaging(paging: Paging): Observable<any> {
        const url = `${environment.apiUrl}/${this.PhaseUrl}/page`;
        return this.http.post<any>(url,paging, this.httpOptions);
    }

    // Tạo mới Phase
    addPhase(Phase: Phase): Observable<any>{
        const url = `${environment.apiUrl}/${this.PhaseUrl}`;
        return this.http.post<Phase>(url,Phase,this.httpOptions);
    }

    // Cập nhật Phase
    updatePhase(Phase: Phase): Observable<any>{
        const url = `${environment.apiUrl}/${this.PhaseUrl}`;
        return this.http.put<Phase>(url,Phase,this.httpOptions);
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