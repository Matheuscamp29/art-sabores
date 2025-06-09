/*
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-salgado',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, HeaderComponent],
  templateUrl: './salgado.component.html'
})
export class SalgadoComponent implements OnInit {
  salgados: any[] = [];
  mostrarFormulario = false;
  salgadoForm!: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.http.get<any[]>('https://localhost:32771/api/v1/getSalgados')
      .subscribe(data => this.salgados = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;

    if (this.mostrarFormulario && !this.salgadoForm) {
      this.salgadoForm = this.fb.group({
        nome: ['', Validators.required],
        preco: [0, [Validators.required, Validators.min(0)]],
        estoque: [0, [Validators.required, Validators.min(0)]]
      });
    }
  }

  salvarSalgado() {
    if (this.salgadoForm.valid) {
      const novoSalgado = this.salgadoForm.value;
      this.salgados.push(novoSalgado); // Simulação local
      this.mostrarFormulario = false;
      this.salgadoForm.reset();
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.salgadoForm) this.salgadoForm.reset();
  }
}
*/
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-salgado',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, HeaderComponent],
  templateUrl: './salgado.component.html'
})
export class SalgadoComponent implements OnInit {
  salgados: any[] = [];
  mostrarFormulario = false;
  salgadoForm!: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.http.get<any[]>('https://localhost:32771/api/v1/getSalgados')
      .subscribe(data => this.salgados = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;

    if (this.mostrarFormulario && !this.salgadoForm) {
      this.salgadoForm = this.fb.group({
        nome: ['', Validators.required],
        preco: [0, [Validators.required, Validators.min(0)]],
        estoque: [0, [Validators.required, Validators.min(0)]]
      });
    }
  }

  salvarSalgado() {
    if (this.salgadoForm.valid) {
      const novoSalgado = this.salgadoForm.value;

      // Envia para a API
      this.http.post('https://localhost:32771/api/v1/salgado', novoSalgado)
        .subscribe(response => {
          this.salgados.push(response); // Adiciona o novo salgado após resposta do backend
          this.mostrarFormulario = false;
          this.salgadoForm.reset();
        });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.salgadoForm) this.salgadoForm.reset();
  }
}
