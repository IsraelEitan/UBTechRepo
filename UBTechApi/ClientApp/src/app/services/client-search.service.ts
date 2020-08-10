import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpHeaderResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IPerson } from '../interfaces/person';

@Injectable()
export class ClientSearchService {

  endPoint: string;
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  private options = new HttpHeaderResponse({ headers: this.headers });

  constructor(private http: HttpClient) {
    this.endPoint = "http://localhost:5000/api/Person/GetPersonList/term";
   
  }

  search(term: any): Observable<IPerson[]> {

    return this.http.get<IPerson[]>(this.endPoint + '?term=' + term, this.options).pipe(
      map((res) => {
        return (res.length != 0 ? res : null);
      })
    );

;
  }
}  
