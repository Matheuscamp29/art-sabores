import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FornecedorComponent } from './pages/fornecedor/fornecedor.component';
import { MateriaPrimaComponent } from './pages/materia-prima/materia-prima.component';


export const routes: Routes = [
  { path: '', redirectTo: 'fornecedor', pathMatch: 'full' },
  { path: 'fornecedor', component: FornecedorComponent }, 
  { path: 'materiaPrima', component: MateriaPrimaComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
