import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HeaderComponent } from "../header/header.component";


@Component({
  selector: 'app-materia-prima',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule, // Aqui importa o HttpClientModule
    ReactiveFormsModule,
    HeaderComponent
],
  templateUrl: './materia-prima.component.html',
  styleUrls: ['./materia-prima.component.css']
})

export class MateriaPrimaComponent {
fornecedores: any;
itens: any;
salvarMP() {
throw new Error('Method not implemented.');
}
  mostrarFormulario = false;
  materiaPrimaForm: FormGroup;
  materias: { nome: string; estoque: number }[] = [];

  constructor(private fb: FormBuilder) {
    this.materiaPrimaForm = this.fb.group({
      nome: ['', Validators.required],
      estoque: [0, [Validators.required, Validators.min(0)]],
    });
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
  }

  salvarMateria() {
    if (this.materiaPrimaForm.valid) {
      this.materias.push(this.materiaPrimaForm.value);
      this.mostrarFormulario = false;
      this.materiaPrimaForm.reset({ nome: '', estoque: 0 });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.materiaPrimaForm.reset({ nome: '', estoque: 0 });
  }
}
