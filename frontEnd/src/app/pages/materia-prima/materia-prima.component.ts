import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, AbstractControl } from '@angular/forms';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-materia-prima',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './materia-prima.component.html'
})
export class MateriaPrimaComponent implements OnInit {
  itens: any[] = [];
  mostrarFormulario = false;
  materiaPrimaForm!: FormGroup;
  fornecedores: any[] = [];

  private apiUrl = 'https://localhost:32771/api/v1';

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  ngOnInit() {
    this.carregarMateriasPrimas();
    this.carregarFornecedores();

    this.materiaPrimaForm = this.fb.group({
      nome: ['', Validators.required],
      unidadeMedida: ['', [
        Validators.required,
        this.validarUnidadeMedida.bind(this)
      ]],
      quantidadeMinima: [0, [Validators.required, Validators.min(0)]],
      fornecedorId: ['', Validators.required]
    });
  }

  carregarMateriasPrimas() {
    this.http.get<any[]>(`${this.apiUrl}/getMateriasPrimas`)
      .subscribe(data => this.itens = data);
  }

  carregarFornecedores() {
    this.http.get<any[]>(`${this.apiUrl}/getFornecedores`)
      .subscribe(data => this.fornecedores = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
  }

  public salvarMP() {
    if (this.materiaPrimaForm.valid) {
      const novaMateriaPrima = this.materiaPrimaForm.value;
      const fornecedorSelecionado = this.fornecedores.find(f => f.id === novaMateriaPrima.fornecedorId);
      novaMateriaPrima.fornecedorNome = fornecedorSelecionado?.nome || 'Desconhecido';
      
      this.itens.push(novaMateriaPrima);
      this.mostrarFormulario = false;
      this.materiaPrimaForm.reset();
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.materiaPrimaForm.reset();
  }

  validarUnidadeMedida(control: AbstractControl) {
    const unidadesValidas = ['kg', 'g', 'l', 'ml', 'un'];
    return unidadesValidas.includes(control.value?.toLowerCase()) 
      ? null 
      : { unidadeInvalida: true };
  }
}