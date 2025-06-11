import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PedidoFornecedorService {
  private apiUrl = 'https://localhost:32771/api/v1'; // URL da API do back-end

  constructor(private http: HttpClient) {}

  // Método para obter todos os pedidos de fornecedores
  getPedidosFornecedores(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getPedidosFornecedores`);
  }

  // Método para criar um novo pedido de fornecedor
  createPedidoFornecedor(pedido: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/PedidoFornecedor/fechar`, pedido);
  }

  // Método para deletar um pedido de fornecedor
  deletePedidoFornecedor(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/PedidoFornecedor/deletar/${id}`);
  }

  // Método para obter todas as matérias-primas
  getMateriasPrimas(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getMateriasPrimas`);
  }
}
