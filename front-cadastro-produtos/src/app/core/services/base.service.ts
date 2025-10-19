import { HttpClient } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';

export class baseService<T> {
  constructor(protected http: HttpClient, protected baseUrl: string) {}
  
  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.baseUrl).pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }

  getById(id: number): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}/${id}`).pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }

  create(item: T): Observable<T> {
    return this.http.post<T>(this.baseUrl, item).pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }

  update(id: number, item: T): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}/${id}`, item).pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`).pipe(
      catchError((error) => {
        return throwError(() => error);
      })
    );
  }
}