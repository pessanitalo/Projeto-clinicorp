import { AdicionarPacienteComponent } from './paciente/adicionar-paciente/adicionar-paciente.component';
import { ConsultaDetalhesComponent } from './consulta/consulta-remarcar/consulta-remarcar.component';
import { Consulta } from './consulta/models/consulta';
import { ConsultaResolve } from './consulta/services/consulta.resolve';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';
import { ConsultaListComponent } from './consulta/consulta-list/consulta-list.component';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HomeComponent } from './navegacao/home/home.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import {  BsModalService } from 'ngx-bootstrap/modal';
import { MedicoListaComponent } from './medico/medico-lista/medico-lista.component';
import { AdicionarMedicoComponent } from './medico/adicionar-medico/adicionar-medico.component';
import { ConsultaNovaComponent } from './consulta/consulta-nova/consulta-nova.component';
import { ToastrModule } from 'ngx-toastr';
import { ListaPacienteComponent } from './paciente/lista-paciente/lista-paciente.component';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HomeComponent,
    MenuComponent,
    ConsultaListComponent,
    ConsultaDetalhesComponent,
    MedicoListaComponent,
    AdicionarMedicoComponent,
    ConsultaNovaComponent,
    AdicionarPacienteComponent,
    ListaPacienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    BrowserModule, 
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-center',
      preventDuplicates: true,
      progressBar: true
  }),
    ModalModule.forRoot()
  ],
  providers: [ConsultaResolve,BsModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
