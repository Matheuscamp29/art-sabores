import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-materia-prima',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './materia-prima.component.html'
})
export class MateriaPrimaComponent implements OnInit {
  itens: any[] = [];
  mostrarFormulario = false;
  materiaPrimaForm!: FormGroup;
  fornecedores: any[] = []; // Lista de fornecedores para o select

  // URL base da API - ajuste conforme necessário
  private apiUrl = 'https://localhost:32771/api/v1';

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  ngOnInit() {
    this.carregarMateriasPrimas();
    this.carregarFornecedores();

    // Inicializa o formulário assim que o componente é carregado
    this.materiaPrimaForm = this.fb.group({
      nome: ['', Validators.required],
      unidadeMedida: ['', Validators.required],
      quantidadeMinima: [0, [Validators.required, Validators.min(0)]],
      fornecedorId: ['', Validators.required]  // Você pode reativar o Validators.required aqui, se necessário
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

  salvarMateriaPrima() {
  if (this.materiaPrimaForm.valid) {
    const novaMateriaPrima = this.materiaPrimaForm.value;

    // Encontra o nome do fornecedor para exibição
    const fornecedorSelecionado = this.fornecedores.find(f => f.id === novaMateriaPrima.fornecedorId);
    novaMateriaPrima.fornecedorNome = fornecedorSelecionado ? fornecedorSelecionado.nome : 'Desconhecido';

    // Aqui você faria a chamada POST para a API
    // this.http.post(`${this.apiUrl}/addMateriaPrima`, novaMateriaPrima).subscribe(...)

    // Temporário: adiciona localmente
    this.itens.push(novaMateriaPrima);
    this.mostrarFormulario = false;
    this.materiaPrimaForm.reset();
  }
}


  cancelarFormulario() {
    this.mostrarFormulario = false;
    if (this.materiaPrimaForm) {
      this.materiaPrimaForm.reset();
    }
  }

  // Validador personalizado para unidade de medida
  validarUnidadeMedida(control: AbstractControl): { [key: string]: any } | null {
    const unidadesValidas = ['kg', 'g', 'l', 'ml', 'un'];
    if (control.value && !unidadesValidas.includes(control.value.toLowerCase())) {
      return { unidadeInvalida: true };
    }
    return null;
  }
}