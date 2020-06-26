import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { tap, catchError, map } from 'rxjs/operators';
import { Process, Category } from '../models';
import { environment } from 'src/environments/environment';
import { Paging } from '../models/paging';


@Injectable({ providedIn: 'root' })
export class CategoryService {

    private ProcessUrl = 'api/category';

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(
        private http: HttpClient,
    ) { }

    /** GET Process from the server */
    getAll(): Observable<Category[]> {
        return this.http.get<Category[]>(`${environment.apiUrl}/${this.ProcessUrl}`)
    }

    /** GET Process by id. Will 404 if id not found */
    getById(id: number): Observable<Category> {
        const url = `${environment.apiUrl}/${this.ProcessUrl}/${id}`;
        return this.http.get<Category>(url);
    }


    handleError(error) {
        console.log(error.error);
        
        
        return throwError(error);
    }

   
}