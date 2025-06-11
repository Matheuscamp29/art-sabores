import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PedidoClienteService {
  private apiUrl = 'https://localhost:32769/api/v1';

  constructor(private http: HttpClient) {}

  // Buscar todos os pedidos de clientes
  getPedidosClientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getPedidosClientes`);
  }

  // Buscar todos os salgados
  getSalgados(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getSalgados`);
  }

  // Buscar todos os clientes
  getClientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getClientes`);
  }

  // Criar um novo pedido de cliente
  createPedidoCliente(pedido: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/PedidoCliente/fechar`, pedido);
  }

  // Deletar um pedido de cliente
  deletePedidoCliente(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/PedidoCliente/deletar/${id}`);
  }
}