import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-cliente',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, HeaderComponent],
  templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {
  clientes: any[] = [];
  mostrarFormulario = false;
  clienteForm!: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.http.get<any[]>('https://localhost:32771/api/v1/getClientes')
      .subscribe(data => this.clientes = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
    if (this.mostrarFormulario && !this.clienteForm) {
      this.clienteForm = this.fb.group({ nome: ['', Validators.required] });
    }
  }

  salvarCliente() {
    if (this.clienteForm.valid) {
      const novoCliente = this.clienteForm.value;
      this.clientes.push(novoCliente);
      this.mostrarFormulario = false;
      this.clienteForm.reset();
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.clienteForm) this.clienteForm.reset();
  }
}