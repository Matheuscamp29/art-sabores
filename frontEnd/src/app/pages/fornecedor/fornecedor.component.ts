import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // IMPORTANTE
@Component({
  selector: 'app-crud',
  standalone: true, // se for standalone
  imports: [CommonModule], // adicione aqui
  templateUrl: './fornecedor.component.html',
})
export class Fornecedor {
  itens = [
    { id: 1, nome: 'Fornecedor 1', descricao: 'Descrição do Fornecedor 1' },
    { id: 2, nome: 'Fornecedor 2', descricao: 'Descrição do Fornecedor 2' },
  ];

  abrirFormulario() {
    // lógica para abrir modal ou redirecionar para o form
    console.log('Abrir formulário de novo Fornecedor');
  }

  editarItem(item: any) {
    // lógica para editar item
    console.log('Editar fornecedor:', item);
  }

  excluirItem(item: any) {
    // lógica para excluir item
    this.itens = this.itens.filter(i => i !== item);
    console.log('Item excluído:', item);
  }
}
