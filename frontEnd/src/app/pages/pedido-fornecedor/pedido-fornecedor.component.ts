import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { PedidoFornecedorService } from './pedido-fornecedor.service';
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
    HeaderComponent
  ]
})
export class PedidoFornecedorComponent implements OnInit {
  pedidos: any[] = [];
  mostrarFormulario = false;
  pedidoForm!: FormGroup;
  materiasPrimas: any[] = [];
  fornecedores: any[] = [];

  constructor(
    private pedidoFornecedorService: PedidoFornecedorService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.carregarPedidos();
    this.carregarMateriasPrimas();
    this.carregarFornecedores();

    
  }

  getNomeFornecedor(id: number): string {
  const fornecedor = this.fornecedores.find(f => f.id === id);
  return fornecedor ? fornecedor.nome : 'Desconhecido';
}

getNomeMateria(id: number): string {
  const materia = this.materiasPrimas.find(m => m.id === id);
  return materia ? materia.nome : 'Desconhecida';
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
  
  carregarFornecedores() {
    this.pedidoFornecedorService.getFornecedores().subscribe((data) => {
      this.fornecedores = data;
    });
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;

    if (this.mostrarFormulario) {
      this.pedidoForm = this.fb.group({
        idFornecedor: ['', Validators.required],
        itens: this.fb.array([this.criarItem()])
      });
    }
  }

  get itens(): FormArray {
    return this.pedidoForm.get('itens') as FormArray;
  }

  criarItem(): FormGroup {
    return this.fb.group({
      idMateriaPrima: ['', Validators.required],
      quantidade: [1, [Validators.required, Validators.min(1)]]
    });
  }

  adicionarItem() {
    this.itens.push(this.criarItem());
  }

  removerItem(index: number) {
    if (this.itens.length > 1) {
      this.itens.removeAt(index);
    }
  }

  salvarPedido() {
    if (this.pedidoForm.valid) {
      const pedidoDTO = {
        idFornecedor: Number(this.pedidoForm.value.idFornecedor),
        itens: this.pedidoForm.value.itens.map((item: any) => ({
          idMateriaPrima: Number(item.idMateriaPrima),
          quantidade: Number(item.quantidade)
        }))
      };
      this.pedidoFornecedorService.createPedidoFornecedor(pedidoDTO).subscribe({
        next: () => {
          this.carregarPedidos();
          this.mostrarFormulario = false;
          this.pedidoForm.reset();
        },
        error: (err: any) => console.error('Erro ao salvar pedido:', err),
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