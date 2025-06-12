import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalgadoService {
  private apiUrl = 'https://localhost:32779/api/v1';

  constructor(private http: HttpClient) {}

  getSalgados(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getSalgados`);
  }

  createSalgado(salgado: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/salgado`, salgado);
  }

  updateSalgado(id: number, salgado: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/updateSalgado/${id}`, salgado);
  }

  deleteSalgado(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/deleteSalgado/${id}`);
  }
}
