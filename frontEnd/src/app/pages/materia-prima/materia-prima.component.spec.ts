import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-materia-prima',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,   // Aqui importa o HttpClientModule
    ReactiveFormsModule,
  ],
  templateUrl: './materia-prima.component.html',
  styleUrls: ['./materia-prima.component.css']
})

export class MateriaPrimaComponent {
  mostrarFormulario = false;
  materiaForm: FormGroup;
  materias: { nome: string; estoque: number }[] = [];

  constructor(private fb: FormBuilder) {
    this.materiaForm = this.fb.group({
      nome: ['', Validators.required],
      estoque: [0, [Validators.required, Validators.min(0)]],
    });
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
  }

  salvarMateria() {
    if (this.materiaForm.valid) {
      this.materias.push(this.materiaForm.value);
      this.mostrarFormulario = false;
      this.materiaForm.reset({ nome: '', estoque: 0 });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.materiaForm.reset({ nome: '', estoque: 0 });
  }
}
