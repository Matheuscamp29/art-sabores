import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MateriaPrimaService } from './materia-prima.service'; // Importando o serviço
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-materia-prima',
  standalone: true,
  templateUrl: './materia-prima.component.html',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    HeaderComponent // <- necessário para reconhecer <app-header>
  ]
})
export class MateriaPrimaComponent implements OnInit {
  itens: any[] = [];
  mostrarFormulario = false;
  materiaPrimaForm!: FormGroup;
  fornecedores: any[] = [];

  private apiUrl = 'https://localhost:32771/api/v1';

  constructor(
    private materiaPrimaService: MateriaPrimaService, // Injetando o serviço
    private http: HttpClient, 
    private fb: FormBuilder
  ) { }

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
    this.materiaPrimaService.getMateriasPrimas()
      .subscribe((data: any[]) => this.itens = data);
  }

  carregarFornecedores() {
    this.http.get<any[]>(`${this.apiUrl}/getFornecedores`)
      .subscribe(data => this.fornecedores = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
  }

  salvarMP() {
    if (this.materiaPrimaForm.valid) {
      const novaMateriaPrima = this.materiaPrimaForm.value;
      const fornecedorSelecionado = this.fornecedores.find(f => f.id === novaMateriaPrima.fornecedorId);
      novaMateriaPrima.fornecedorNome = fornecedorSelecionado?.nome || 'Desconhecido';

      this.materiaPrimaService.createMateriaPrima(novaMateriaPrima)
        .subscribe((response: any) => {
          this.itens.push(response);  // Adiciona a matéria-prima após resposta do back-end
          this.mostrarFormulario = false;
          this.materiaPrimaForm.reset();
        });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.materiaPrimaForm.reset();
  }

  validarUnidadeMedida(control: any) {
    const unidadesValidas = ['kg', 'g', 'l', 'ml', 'un'];
    return unidadesValidas.includes(control.value?.toLowerCase()) 
      ? null 
      : { unidadeInvalida: true };
  }
}