import { ConsultaDetalhesComponent } from './consulta/consulta-detalhes/consulta-detalhes.component';
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
import { NgxMaskModule } from 'ngx-mask'
import {  BsModalService } from 'ngx-bootstrap/modal';
import { MedicoListaComponent } from './medico/medico-lista/medico-lista.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HomeComponent,
    MenuComponent,
    ConsultaListComponent,
    ConsultaDetalhesComponent,
    MedicoListaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [ConsultaResolve,BsModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
