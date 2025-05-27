import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-fornecedor',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './fornecedor.component.html'
})
export class FornecedorComponent implements OnInit {
  itens: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<any[]>('https://localhost:32771/api/v1/getFornecedores')
      .subscribe(data => this.itens = data);
  }
}