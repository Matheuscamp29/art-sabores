import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-pedido-cliente',
  standalone: true,
  templateUrl: './pedido-cliente.component.html',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    HeaderComponent // <- necessário para reconhecer <app-header>
  ]
})
export class PedidoClienteComponent implements OnInit {
  pedidos: any[] = [];
  mostrarFormulario = false;
  pedidoForm!: FormGroup;
  produtos: any[] = []; // Lista de produtos para o select

  private apiUrl = 'https://localhost:32769/api/v1';

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit() {
    this.carregarPedidos();
    this.carregarProdutos();
  }

  carregarPedidos() {
    this.http.get<any[]>(`${this.apiUrl}/getPedidosClientes`)
      .subscribe(data => this.pedidos = data);
  }

  carregarProdutos() {
    this.http.get<any[]>(`${this.apiUrl}/getSalgados`)
      .subscribe(data => this.produtos = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
    
    if (this.mostrarFormulario) {
      this.pedidoForm = this.fb.group({
        subtotal: [0, [Validators.required, Validators.min(0)]],
        idItem: ['', Validators.required]
      });
    }
  }

  salvarPedido() {
    if (this.pedidoForm.valid) {
      const novoPedido = this.pedidoForm.value;
      
      // Encontra o produto para obter o nome
      const produtoSelecionado = this.produtos.find(p => p.id === novoPedido.idItem);
      novoPedido.produtoNome = produtoSelecionado ? produtoSelecionado.nome : 'Desconhecido';
      
      // Chamada à API para salvar
      this.http.post(`${this.apiUrl}/addPedidoCliente`, novoPedido).subscribe({
        next: () => {
          this.carregarPedidos();
          this.mostrarFormulario = false;
        },
        error: (err) => console.error('Erro ao salvar pedido:', err)
      });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.pedidoForm) {
      this.pedidoForm.reset();
    }
  }
}
