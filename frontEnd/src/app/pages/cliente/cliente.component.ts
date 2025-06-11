import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { ClienteService } from './cliente.service';
import { HeaderComponent } from '../header/header.component'; // <- ajuste o caminho se necessário

@Component({
  selector: 'app-cliente',
  standalone: true,
  templateUrl: './cliente.component.html',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    HeaderComponent // <- necessário para reconhecer <app-header>
  ]
})
export class ClienteComponent implements OnInit {
  clientes: any[] = [];
  mostrarFormulario = false;
  clienteForm!: FormGroup;
  editandoCliente: any = null; // ← variável de controle

  constructor(
    private clienteService: ClienteService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.carregarClientes();
  }

  carregarClientes() {
    this.clienteService.getClientes().subscribe(data => this.clientes = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;

    if (this.mostrarFormulario) {
      this.clienteForm = this.fb.group({
        nome: ['', Validators.required],
        telefone: ['', [Validators.required, Validators.pattern('^\\+?[0-9]*$')]]
      });
    }
  }

  editarCliente(cliente: any) {
    this.editandoCliente = cliente;
    this.mostrarFormulario = true;

    this.clienteForm = this.fb.group({
      nome: [cliente.nome, Validators.required],
      telefone: [cliente.telefone, [Validators.required, Validators.pattern('^\\+?[0-9]*$')]]
    });
  }

  excluirCliente(cliente: any) {
    const confirmacao = confirm(`Deseja realmente excluir o cliente "${cliente.nome}"?`);

    if (confirmacao) {
      this.clienteService.deleteCliente(cliente.id).subscribe(() => {
        this.clientes = this.clientes.filter(c => c !== cliente);
      });
    }
  }

  salvarCliente() {
    if (this.clienteForm.valid) {
      const clienteFormValue = this.clienteForm.value;

      if (this.editandoCliente) {
        // Edição
        this.clienteService.updateCliente(this.editandoCliente.id, clienteFormValue)
          .subscribe(resposta => {
            const index = this.clientes.findIndex(c => c.id === this.editandoCliente.id);
            if (index !== -1) this.clientes[index] = resposta;

            this.mostrarFormulario = false;
            this.clienteForm.reset();
            this.editandoCliente = null;
          });
      } else {
        // Criação
        this.clienteService.createCliente(clienteFormValue)
          .subscribe(resposta => {
            this.clientes.push(resposta);
            this.mostrarFormulario = false;
            this.clienteForm.reset(); 
          });
      }
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.clienteForm.reset();
    this.editandoCliente = null;
  }
}

