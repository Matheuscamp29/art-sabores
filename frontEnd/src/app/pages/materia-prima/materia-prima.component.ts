import { Component } from '@angular/core';

@Component({
  selector: 'app-materia-prima',
  imports: [
    CommonModule,
    HttpClientModule,   // pra usar HttpClient em serviços/injeções
    ReactiveFormsModule // para usar formulários reativos (formGroup, formControl)
  ],
  templateUrl: './materia-prima.component.html',
  styleUrl: './materia-prima.component.scss'
})
export class MateriaPrimaComponent {

}
