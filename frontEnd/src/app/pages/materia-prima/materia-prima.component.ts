import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MateriaPrimaService } from './materia-prima.service';
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
    HeaderComponent
  ]
})
export class MateriaPrimaComponent implements OnInit {
  itens: any[] = [];
  mostrarFormulario = false;
  materiaPrimaForm!: FormGroup;
  fornecedores: any[] = [];
  editandoMP: any = null; // <- variável de controle

  private apiUrl = 'https://localhost:32769/api/v1';

  constructor(
    private materiaPrimaService: MateriaPrimaService,
    private http: HttpClient, 
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.carregarMateriasPrimas();
    this.carregarFornecedores();

    this.inicializarFormulario();
  }

  inicializarFormulario() {
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

    if (!this.mostrarFormulario) {
      this.editandoMP = null;
      this.materiaPrimaForm.reset();
    }
  }

  salvarMP() {
    if (this.materiaPrimaForm.valid) {
      const formValue = this.materiaPrimaForm.value;
      const fornecedorSelecionado = this.fornecedores.find(f => f.id === formValue.fornecedorId);
      formValue.fornecedorNome = fornecedorSelecionado?.nome || 'Desconhecido';

      if (this.editandoMP) {
        // Atualização
        this.materiaPrimaService.updateMateriaPrima(this.editandoMP.id, formValue)
          .subscribe(response => {
            const index = this.itens.findIndex(mp => mp.id === this.editandoMP.id);
            if (index !== -1) this.itens[index] = response;

            this.resetarFormulario();
          });
      } else {
        // Criação
        this.materiaPrimaService.createMateriaPrima(formValue)
          .subscribe(response => {
            this.itens.push(response);
            this.resetarFormulario();
          });
      }
    }
  }

  editarMateriaPrima(item: any) {
    this.editandoMP = item;
    this.mostrarFormulario = true;

    this.materiaPrimaForm = this.fb.group({
      nome: [item.nome, Validators.required],
      unidadeMedida: [item.unidadeMedida, [
        Validators.required,
        this.validarUnidadeMedida.bind(this)
      ]],
      quantidadeMinima: [item.quantidadeMinima, [Validators.required, Validators.min(0)]],
      fornecedorId: [item.fornecedorId, Validators.required]
    });
  }

  excluirMateriaPrima(id: number) {
    const confirmacao = confirm('Deseja realmente excluir esta matéria-prima?');

    if (confirmacao) {
      this.materiaPrimaService.deleteMateriaPrima(id)
        .subscribe(() => {
          this.itens = this.itens.filter(item => item.id !== id);
        });
    }
  }

  cancelarFormulario() {
    this.resetarFormulario();
  }

  resetarFormulario() {
    this.mostrarFormulario = false;
    this.materiaPrimaForm.reset();
    this.editandoMP = null;
  }

  validarUnidadeMedida(control: any) {
    const unidadesValidas = ['kg', 'g', 'l', 'ml', 'un'];
    return unidadesValidas.includes(control.value?.toLowerCase()) 
      ? null 
      : { unidadeInvalida: true };
  }
}
