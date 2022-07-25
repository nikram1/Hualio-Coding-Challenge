import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private apiUrl = environment.apiUrl;
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  getProducts(body: any): Observable<any> {
    return this.http.post(`${this.apiUrl}products/getProducts`, body)
      .pipe(
        tap(_ => this.log('fetched Products')),
        catchError(this.handleError<any>('getHeaders'))
      );
  }

  getProductById(productId: any): Observable<any> {
    return this.http.get(`${this.apiUrl}products/getProductById/${productId}`)
      .pipe(
        tap(_ => this.log('get Product by id')),
        catchError(this.handleError<any>('getHeaders'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

   private log(message: string) {
    console.log(message)
  }
}