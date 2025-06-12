import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MateriaPrimaService {
  private apiUrl = 'https://localhost:32779/api/v1'; // URL da API do back-end

  constructor(private http: HttpClient) { }

  // Método para obter todas as matérias-primas
  getMateriasPrimas(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getMateriasPrimas`);
  }

  // Método para criar uma nova matéria-prima
  createMateriaPrima(materiaPrima: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/materia_prima`, materiaPrima);
  }

  // Método para atualizar uma matéria-prima existente
  updateMateriaPrima(id: number, materiaPrima: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/updateMateriaPrima/${id}`, materiaPrima);
  }

  // Método para deletar uma matéria-prima
  deleteMateriaPrima(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/deleteMateriaPrima/${id}`);
  }
}
