import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { PedidoClienteService } from './pedido-cliente.service'; // <-- IMPORTANTE!
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
    HeaderComponent
  ]
})
export class PedidoClienteComponent implements OnInit {
  public pedidos: any[] = [];
  public mostrarFormulario = false;
  public pedidoForm!: FormGroup;
  public produtos: any[] = [];
  public clientes: any[] = [];

  private apiUrl = 'https://localhost:32777/api/v1';

  constructor(
    private http: HttpClient,
    private fb: FormBuilder,
    private pedidoClienteService: PedidoClienteService // <-- INJETADO AQUI!
  ) {}

  public ngOnInit() {
    this.carregarProdutos();
    this.carregarClientes();
    this.carregarPedidos();
  }
  public carregarPedidos() {
    this.http.get<any[]>(`${this.apiUrl}/PedidoCliente/get`)
      .subscribe(data => this.pedidos = data);
  }
  public carregarProdutos() {
    this.http.get<any[]>(`${this.apiUrl}/getSalgados`)
      .subscribe(data => this.produtos = data);
  }

  public carregarClientes() {
    this.http.get<any[]>(`${this.apiUrl}/getClientes`)
      .subscribe(data => this.clientes = data);
  }

  public getTotalPedido(pedido: any): number {
    return pedido.itens.reduce((total: number, item: any) => total + (item.subtotal || 0), 0);
  }

  public toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;

    if (this.mostrarFormulario) {
      this.pedidoForm = this.fb.group({
        idCliente: ['', Validators.required],
        itens: this.fb.array([this.criarItem()])
      });
    }
  }

  public get itens(): FormArray {
    return this.pedidoForm.get('itens') as FormArray;
  }

  public criarItem(): FormGroup {
    return this.fb.group({
      idSalgado: ['', Validators.required],
      quantidade: [1, [Validators.required, Validators.min(1)]]
    });
  }

  public adicionarItem() {
    this.itens.push(this.criarItem());
  }

  public removerItem(index: number) {
    if (this.itens.length > 1) {
      this.itens.removeAt(index);
    }
  }

  public salvarPedido() {
  if (this.pedidoForm.valid) {
    const pedidoDTO = {
      idCliente: Number(this.pedidoForm.value.idCliente),
      itens: this.pedidoForm.value.itens.map((item: any) => ({
        idSalgado: Number(item.idSalgado),
        quantidade: Number(item.quantidade)
      }))
    };

    this.pedidoClienteService.createPedidoCliente(pedidoDTO).subscribe({
      next: () => {
        this.carregarPedidos();
        this.mostrarFormulario = false;
        this.pedidoForm.reset();
      },
      error: (err) => {
        alert('Erro ao salvar pedido');
        console.error('Erro ao salvar pedido:', err);
      }
    });
  }
}

  public cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.pedidoForm) {
      this.pedidoForm.reset();
    }
  }

  public getNomeProduto(id: number) {
    const prod = this.produtos.find(p => p.id === id);
    return prod ? prod.nome : 'Desconhecido';
  }

  public getNomeCliente(id: number) {
    const cli = this.clientes.find(c => c.id === id);
    return cli ? cli.nome : 'Desconhecido';
  }
}