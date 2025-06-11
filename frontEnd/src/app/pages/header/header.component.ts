import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
})
export class HeaderComponent {
  isMenuOpen = false;

  // Mapeamento das rotas para nomes amigáveis
  pageTitles: { [key: string]: string } = {
    '/fornecedor': 'Fornecedores',
    '/cliente': 'Clientes',
    '/pedido-fornecedor': 'Pedidos Fornecedor',
    '/pedido-cliente': 'Pedidos Clientes',
    '/estoque': 'Estoque',
  };

  menuPages = [
    { path: '/fornecedor', title: 'Fornecedores' },
    { path: '/cliente', title: 'Clientes' },
    { path: '/pedido-cliente', title: 'Pedidos Clientes' },
    { path: '/pedido-fornecedor', title: 'Pedidos Fornecedores' },
    { path: '/estoque', title: 'Estoque' },
  ];


  constructor(public router: Router) { }

  get currentPageTitle(): string {
    // Trata a rota raiz que redireciona para fornecedor
    if (this.router.url === '/') {
      return this.pageTitles['/fornecedor'];
    }
    return this.pageTitles[this.router.url] || 'Página Atual';
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  closeMenu() {
    this.isMenuOpen = false;
  }
}