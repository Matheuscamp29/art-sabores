import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FornecedorComponent } from './pages/fornecedor/fornecedor.component';
import { MateriaPrimaComponent } from './pages/materia-prima/materia-prima.component';
import { ClienteComponent } from './pages/cliente/cliente.component';


export const routes: Routes = [
  { path: '', redirectTo: 'fornecedor', pathMatch: 'full' },
  { path: 'fornecedor', component: FornecedorComponent }, 
  { path: 'materiaPrima', component: MateriaPrimaComponent },
  { path: 'cliente', component: ClienteComponent } 
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
