import { Routes } from "@angular/router";
import { ConsultaListComponent } from "./consulta/consulta-list/consulta-list.component";
import { ConsultaNovaComponent } from "./consulta/consulta-nova/consulta-nova.component";
import { ConsultaDetalhesComponent } from "./consulta/consulta-remarcar/consulta-remarcar.component";
import { ConsultaResolve } from "./consulta/services/consulta.resolve";
import { AdicionarMedicoComponent } from "./medico/adicionar-medico/adicionar-medico.component";
import { MedicoListaComponent } from "./medico/medico-lista/medico-lista.component";
import { AdicionarPacienteComponent } from "./paciente/adicionar-paciente/adicionar-paciente.component";
import { ListaPacienteComponent } from "./paciente/lista-paciente/lista-paciente.component";

export const APP_ROUTES: Routes = [
    { path: 'consultalist', component: ConsultaListComponent },
    { path: 'medicolist', component: MedicoListaComponent },
    { path: 'lista', component: ListaPacienteComponent },
    { path: 'nova-consulta', component: ConsultaNovaComponent },
    { path: 'adicionar', component: AdicionarMedicoComponent },
    { path: 'novopaciente', component: AdicionarPacienteComponent },
    { path: 'edit/:id', component: ConsultaDetalhesComponent, resolve: { consulta: ConsultaResolve } },
] 