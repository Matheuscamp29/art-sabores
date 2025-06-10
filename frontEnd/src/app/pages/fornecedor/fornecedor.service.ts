import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FornecedorService {
  private apiUrl = 'https://localhost:32769/api/v1';

  constructor(private http: HttpClient) {}

  getFornecedores(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getFornecedores`);
  }

  createFornecedor(fornecedor: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/fornecedor`, fornecedor);
  }

  updateFornecedor(id: number, fornecedor: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/updateFornecedor/${id}`, fornecedor);
  }

  deleteFornecedor(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/deleteFornecedor/${id}`);
  }
}
