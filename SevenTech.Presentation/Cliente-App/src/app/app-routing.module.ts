import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './components/cliente/cliente.component';
import { RegistrarClienteComponent } from './components/cliente/registrar-cliente/registrar-cliente.component';

const routes: Routes = [
  { path: 'cliente', component: ClienteComponent },
  { path: 'cliente/:id/registrarcliente', component: RegistrarClienteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
