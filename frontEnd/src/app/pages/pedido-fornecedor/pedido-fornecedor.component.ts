import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-pedido-fornecedor',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HeaderComponent],
  templateUrl: './pedido-fornecedor.component.html'
})
export class PedidoFornecedorComponent implements OnInit {
  pedidos: any[] = [];
  mostrarFormulario = false;
  pedidoForm!: FormGroup;
  materiasPrimas: any[] = []; // Lista de matérias primas para o select

  private apiUrl = 'https://localhost:32771/api/v1';

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit() {
    this.carregarPedidos();
    this.carregarMateriasPrimas();
  }

  carregarPedidos() {
    this.http.get<any[]>(`${this.apiUrl}/getPedidosFornecedores`)
      .subscribe(data => this.pedidos = data);
  }

  carregarMateriasPrimas() {
    this.http.get<any[]>(`${this.apiUrl}/getMateriasPrimas`)
      .subscribe(data => this.materiasPrimas = data);
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
      
      // Encontra a matéria prima para obter o nome
      const materiaSelecionada = this.materiasPrimas.find(m => m.id === novoPedido.idItem);
      novoPedido.materiaPrimaNome = materiaSelecionada ? materiaSelecionada.nome : 'Desconhecido';
      
      // Chamada à API para salvar
      this.http.post(`${this.apiUrl}/addPedidoFornecedor`, novoPedido).subscribe({
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