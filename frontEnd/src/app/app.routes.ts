import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FornecedorComponent } from './pages/fornecedor/fornecedor.component';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { EstoqueComponent } from './pages/estoque/estoque.component';
import { MateriaPrimaComponent } from './pages/materia-prima/materia-prima.component';
import { SalgadoComponent } from './pages/salgado/salgado.component';
import { PedidoClienteComponent } from './pages/pedido-cliente/pedido-cliente.component';
import { PedidoFornecedorComponent } from './pages/pedido-fornecedor/pedido-fornecedor.component';



export const routes: Routes = [
  { path: '', redirectTo: 'fornecedor', pathMatch: 'full' },
  { path: 'fornecedor', component: FornecedorComponent }, 
  { path: 'estoque', component: EstoqueComponent },
  { path: 'materiaPrima', component: MateriaPrimaComponent },
  { path: 'salgado', component: SalgadoComponent},
  { path: 'cliente', component: ClienteComponent },
  { path: 'pedido-cliente', component: PedidoClienteComponent},
  { path: 'pedido-fornecedor', component: PedidoFornecedorComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
