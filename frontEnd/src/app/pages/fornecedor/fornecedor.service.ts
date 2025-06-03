// services/fornecedor.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FornecedorService {
  private apiUrl = ''; // Substitua pela sua URL

  constructor(private http: HttpClient) {}

  getFornecedores(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}