import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FornecedorService } from './fornecedor.service'; // <- IMPORTANTE
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from '../header/header.component';

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

  constructor(
    private fornecedorService: FornecedorService, // <- AQUI
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.fornecedorService.getFornecedores()
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

      // ✅ Enviar para a API
      this.fornecedorService.createFornecedor(novoFornecedor).subscribe(resposta => {
        this.itens.push(resposta); // resposta do backend
        this.mostrarFormulario = false;
        this.fornecedorForm.reset();
      });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.fornecedorForm.reset();
  }

  validarCNPJ(control: any) {
    // Coloque aqui sua validação de CNPJ
    return null;
  }
}
