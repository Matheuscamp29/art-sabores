import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SalgadoService } from './salgado.service'; // <- AQUI
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cliente',
  standalone: true,
  templateUrl: './salgado.component.html',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    HeaderComponent // <- necessário para reconhecer <app-header>
  ]
})
export class SalgadoComponent implements OnInit {
  salgados: any[] = [];
  mostrarFormulario = false;
  salgadoForm!: FormGroup;

  constructor(
    private http: HttpClient,
    private salgadoService: SalgadoService, // <- AQUI
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.salgadoService.getSalgados()
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

      this.salgadoService.createSalgado(novoSalgado)
        .subscribe(response => {
          this.salgados.push(response);
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
