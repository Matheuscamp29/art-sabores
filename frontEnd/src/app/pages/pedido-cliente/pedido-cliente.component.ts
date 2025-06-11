import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
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
  public pedidos: any[] = []; // Lista local
  public mostrarFormulario = false;
  public pedidoForm!: FormGroup;
  public produtos: any[] = [];
  public clientes: any[] = [];

  private apiUrl = 'https://localhost:32769/api/v1';

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  public ngOnInit() {
    this.carregarProdutos();
    this.carregarClientes();
  }

  public carregarProdutos() {
    this.http.get<any[]>(`${this.apiUrl}/getSalgados`)
      .subscribe(data => this.produtos = data);
  }

  public carregarClientes() {
    this.http.get<any[]>(`${this.apiUrl}/getClientes`)
      .subscribe(data => this.clientes = data);
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

      this.pedidos.push(pedidoDTO);
      this.mostrarFormulario = false;
      this.pedidoForm.reset();
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