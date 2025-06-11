import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ClienteService } from './cliente.service';
import { HeaderComponent } from "../header/header.component"; // <- IMPORTANTE
import { CommonModule } from '@angular/common';

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

  constructor(
    private http: HttpClient,
    private clienteService: ClienteService, // <- AQUI
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.clienteService.getClientes()
      .subscribe(data => this.clientes = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
    if (this.mostrarFormulario && !this.clienteForm) {
      this.clienteForm = this.fb.group({
        nome: ['', Validators.required],
        telefone: ['', [Validators.required, Validators.pattern('^\\+?[0-9]*$')]]
      });
    }
  }

  salvarCliente() {
    if (this.clienteForm.valid) {
      const novoCliente = this.clienteForm.value;
      this.clienteService.createCliente(novoCliente)
        .subscribe(response => {
          this.clientes.push(response);
          this.mostrarFormulario = false;
          this.clienteForm.reset();
        });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.clienteForm) this.clienteForm.reset();
  }
}
