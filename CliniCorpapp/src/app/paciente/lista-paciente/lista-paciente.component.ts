import { PacienteService } from './../services/paciente.service';
import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/consulta/models/paciente';

@Component({
  selector: 'app-lista-paciente',
  templateUrl: './lista-paciente.component.html',
  styleUrls: ['./lista-paciente.component.css']
})
export class ListaPacienteComponent implements OnInit {

  pacientes!: Paciente[];

  constructor(
    private pacienteService: PacienteService,
  ) { }

  ngOnInit(): void {
    this.listapacientes();
  }

  listapacientes(){
    this.pacienteService.list().subscribe(
      medicos => this.pacientes = medicos,
      error => (console.log(error))
    );
  }

}
