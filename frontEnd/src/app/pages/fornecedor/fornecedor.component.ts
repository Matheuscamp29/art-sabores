import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { HeaderComponent } from '../header/header.component'; // ajuste conforme seu caminho real

@Component({
  selector: 'app-fornecedor',
  standalone: true,
  imports: [CommonModule, HttpClientModule, ReactiveFormsModule, HeaderComponent],
  templateUrl: './fornecedor.component.html'
})
export class FornecedorComponent implements OnInit {
  itens: any[] = [];
  mostrarFormulario = false;
  fornecedorForm!: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {}

  ngOnInit() {
    this.http.get<any[]>('https://localhost:32771/api/v1/getFornecedores')
      .subscribe(data => this.itens = data);
  }

  abrirFormulario() {
    this.mostrarFormulario = true;
    this.fornecedorForm = this.fb.group({
      nome: ['', Validators.required],
      cnpj: ['', [Validators.required, this.validarCNPJ]]
    });
  }

  salvarFornecedor() {
    if (this.fornecedorForm.valid) {
      const novoFornecedor = this.fornecedorForm.value;
      this.itens.push(novoFornecedor);
      this.mostrarFormulario = false;
      this.fornecedorForm.reset();
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.fornecedorForm.reset();
  }

  validarCNPJ(control: AbstractControl): ValidationErrors | null {
    const cnpj = control.value?.replace(/[^\d]+/g, '');
  
    if (!cnpj || cnpj.length !== 14 || /^(\d)\1+$/.test(cnpj)) {
      return { cnpjInvalido: true };
    }
  
    let tamanho = cnpj.length - 2;
    let numeros = cnpj.substring(0, tamanho);
    const digitos = cnpj.substring(tamanho);
    let soma = 0;
    let pos = tamanho - 7;
  
    for (let i = tamanho; i >= 1; i--) {
      soma += +numeros.charAt(tamanho - i) * pos--;
      if (pos < 2) pos = 9;
    }
  
    let resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);
    if (resultado !== +digitos.charAt(0)) return { cnpjInvalido: true };
  
    tamanho += 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
  
    for (let i = tamanho; i >= 1; i--) {
      soma += +numeros.charAt(tamanho - i) * pos--;
      if (pos < 2) pos = 9;
    }
  
    resultado = soma % 11 < 2 ? 0 : 11 - (soma % 11);
    if (resultado !== +digitos.charAt(1)) return { cnpjInvalido: true };
  
    // ✅ Adicione este return para satisfazer o TypeScript
    return null;
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
  
    if (this.mostrarFormulario && !this.fornecedorForm) {
      this.fornecedorForm = this.fb.group({
        nome: ['', Validators.required],
        cnpj: ['', [Validators.required, this.validarCNPJ]]
      });
    }
  }
}