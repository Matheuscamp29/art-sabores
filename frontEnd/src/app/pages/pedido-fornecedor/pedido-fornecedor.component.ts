import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PedidoFornecedorService } from './pedido-fornecedor.service'; // Importando o serviço
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-pedido-fornecedor',
  standalone: true,
  templateUrl: './pedido-fornecedor.component.html',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    HeaderComponent // <- necessário para reconhecer <app-header>
  ]
})
export class PedidoFornecedorComponent implements OnInit {
  pedidos: any[] = [];
  mostrarFormulario = false;
  pedidoForm!: FormGroup;
  materiasPrimas: any[] = [];

  constructor(
    private pedidoFornecedorService: PedidoFornecedorService, // Injetando o serviço
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.carregarPedidos();
    this.carregarMateriasPrimas();
  }

  carregarPedidos() {
    this.pedidoFornecedorService.getPedidosFornecedores().subscribe((data) => {
      this.pedidos = data;
    });
  }

  carregarMateriasPrimas() {
    this.pedidoFornecedorService.getMateriasPrimas().subscribe((data) => {
      this.materiasPrimas = data;
    });
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;

    if (this.mostrarFormulario) {
      this.pedidoForm = this.fb.group({
        subtotal: [0, [Validators.required, Validators.min(0)]],
        idItem: ['', Validators.required],
      });
    }
  }

  salvarPedido() {
    if (this.pedidoForm.valid) {
      const novoPedido = this.pedidoForm.value;

      // Encontra a matéria prima para obter o nome
      const materiaSelecionada = this.materiasPrimas.find(
        (m) => m.id === novoPedido.idItem
      );
      novoPedido.materiaPrimaNome = materiaSelecionada
        ? materiaSelecionada.nome
        : 'Desconhecido';

      // Chama o serviço para salvar o pedido
      this.pedidoFornecedorService.createPedidoFornecedor(novoPedido).subscribe({
        next: () => {
          this.carregarPedidos();
          this.mostrarFormulario = false;
        },
        error: (err) => console.error('Erro ao salvar pedido:', err),
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
