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
  editandoFornecedor: any = null;
  itens: any[] = [];
  mostrarFormulario = false;
  fornecedorForm!: FormGroup;

  constructor(
    private fornecedorService: FornecedorService, // <- AQUI
    private fb: FormBuilder
  ) { }

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
  editarFornecedor(fornecedor: any) {
    this.mostrarFormulario = true;
    this.fornecedorForm = this.fb.group({
      nome: [fornecedor.nome, Validators.required],
      cnpj: [fornecedor.cnpj, [Validators.required, this.validarCNPJ]]
    });

    // Pode guardar o ID ou o próprio objeto para saber que está editando
    this.editandoFornecedor = fornecedor; // <- precisa declarar essa variável no topo
  }

  excluirFornecedor(fornecedor: any) {
    const confirmacao = confirm(`Tem certeza que deseja excluir o fornecedor "${fornecedor.nome}"?`);
    if (confirmacao) {
      // Caso use backend:
      this.fornecedorService.deleteFornecedor(fornecedor.id).subscribe(() => {
        this.itens = this.itens.filter(f => f !== fornecedor);
      });

      // Caso esteja apenas em memória:
      // this.itens = this.itens.filter(f => f !== fornecedor);
    }
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
