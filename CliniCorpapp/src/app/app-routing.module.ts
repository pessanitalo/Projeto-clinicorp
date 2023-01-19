import { AdicionarMedicoComponent } from './medico/adicionar-medico/adicionar-medico.component';
import { MedicoListaComponent } from './medico/medico-lista/medico-lista.component';
import { ConsultaDetalhesComponent } from './consulta/consulta-detalhes/consulta-detalhes.component';
import { ConsultaListComponent } from './consulta/consulta-list/consulta-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultaResolve } from './consulta/services/consulta.resolve';
import { ConsultaNovaComponent } from './consulta/consulta-nova/consulta-nova.component';

const routes: Routes = [
  { path: 'consultalist', component: ConsultaListComponent },
  { path: 'medicolist', component: MedicoListaComponent },
  { path: 'nova-consulta', component: ConsultaNovaComponent },
  { path: 'adicionar', component: AdicionarMedicoComponent },
  { path: 'edit/:id', component: ConsultaDetalhesComponent, resolve: { consulta: ConsultaResolve } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
