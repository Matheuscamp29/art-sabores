import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FornecedorComponent } from './pages/fornecedor/fornecedor.component';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { EstoqueComponent } from './pages/estoque/estoque.component';



export const routes: Routes = [
  { path: '', redirectTo: 'fornecedor', pathMatch: 'full' },
  { path: 'fornecedor', component: FornecedorComponent }, 
  { path: 'estoque', component: EstoqueComponent },
  { path: 'cliente', component: ClienteComponent } 
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
