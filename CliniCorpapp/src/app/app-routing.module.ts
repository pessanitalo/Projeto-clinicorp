import { ConsultaDetalhesComponent } from './consulta/consulta-detalhes/consulta-detalhes.component';
import { ClienteListComponent } from './cliente/cliente-list/cliente-list.component';
import { ConsultaListComponent } from './consulta/consulta-list/consulta-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultaResolve } from './consulta/services/consulta.resolve';

const routes: Routes = [
  { path: 'consultalist', component: ConsultaListComponent },
  { path: 'pacienteslist', component: ClienteListComponent },
   { path: 'getid/:id', component: ConsultaDetalhesComponent, resolve: { consulta: ConsultaResolve } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
