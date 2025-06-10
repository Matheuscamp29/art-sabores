import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MateriaPrimaComponent } from '../materia-prima/materia-prima.component';
import { SalgadoComponent } from '../salgado/salgado.component';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-estoque',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    MateriaPrimaComponent,
    SalgadoComponent
  ],
  templateUrl: './estoque.component.html',
})
export class EstoqueComponent {}
