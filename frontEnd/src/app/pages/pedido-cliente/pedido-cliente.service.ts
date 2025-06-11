import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PedidoClienteService {
  private apiUrl = 'https://localhost:32771/api/v1';

  constructor(private http: HttpClient) {}

  // Método para obter todos os pedidos de clientes
  getPedidosClientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getPedidosClientes`);
  }

    // Método para obter todos os pedidos de clientes
  getSalgados(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getSalgados`);
  }


  // Método para criar um novo pedido de cliente
  createPedidoCliente(pedido: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/PedidoCliente/fechar`, pedido);
  }

  // Método para deletar um pedido de cliente
  deletePedidoCliente(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/PedidoCliente/deletar/${id}`);
  }
}
