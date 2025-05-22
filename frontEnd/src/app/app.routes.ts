import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Fornecedor } from './pages/fornecedor/fornecedor.component'; // importe aqui

export const routes: Routes = [
  { path: '', redirectTo: 'fornecedor', pathMatch: 'full' },
  { path: 'fornecedor', component: Fornecedor },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
