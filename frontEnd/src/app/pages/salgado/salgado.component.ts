import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SalgadoService } from './salgado.service';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-salgado',
  standalone: true,
  templateUrl: './salgado.component.html',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    HeaderComponent 
  ]
})
export class SalgadoComponent implements OnInit {
  salgados: any[] = [];
  mostrarFormulario = false;
  salgadoForm!: FormGroup;
  salgadoEditando: any = null; // <- usado para edição

  constructor(
    private http: HttpClient,
    private salgadoService: SalgadoService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.salgadoService.getSalgados()
      .subscribe(data => this.salgados = data);
  }

  toggleFormulario() {
    this.mostrarFormulario = !this.mostrarFormulario;
    if (this.mostrarFormulario && !this.salgadoForm) {
      this.inicializarFormulario();
    }
  }

  inicializarFormulario() {
    this.salgadoForm = this.fb.group({
      nome: ['', Validators.required],
      preco: [0, [Validators.required, Validators.min(0)]],
      estoque: [0, [Validators.required, Validators.min(0)]]
    });
  }

  salvarSalgado() {
    if (this.salgadoForm.invalid) return;

    const dados = this.salgadoForm.value;

    if (this.salgadoEditando) {
      this.salgadoService.updateSalgado(this.salgadoEditando.id, dados)
        .subscribe(response => {
          const index = this.salgados.findIndex(s => s.id === this.salgadoEditando.id);
          if (index > -1) this.salgados[index] = response;
          this.cancelarFormulario();
        });
    } else {
      this.salgadoService.createSalgado(dados)
        .subscribe(response => {
          this.salgados.push(response);
          this.cancelarFormulario();
        });
    }
  }

  editarSalgado(salgado: any) {
    this.salgadoEditando = salgado;
    this.mostrarFormulario = true;

    if (!this.salgadoForm) this.inicializarFormulario();

    this.salgadoForm.patchValue({
      nome: salgado.nome,
      preco: salgado.preco,
      estoque: salgado.estoque
    });
  }

  excluirSalgado(id: number) {
    if (confirm('Tem certeza que deseja excluir?')) {
      this.salgadoService.deleteSalgado(id)
        .subscribe(() => {
          this.salgados = this.salgados.filter(s => s.id !== id);
        });
    }
  }

  cancelarFormulario() {
    this.mostrarFormulario = false;
    this.salgadoEditando = null;
    if (this.salgadoForm) this.salgadoForm.reset();
  }
}
