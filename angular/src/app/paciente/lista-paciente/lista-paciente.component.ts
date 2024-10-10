import { Component } from '@angular/core';
import { PacienteService } from './../services/paciente.service';
import { Paciente } from 'src/app/consulta/models/paciente';
import { RouterLink } from '@angular/router';

@Component({
    selector: 'app-lista-paciente',
    templateUrl: './lista-paciente.component.html',
    styleUrls: ['./lista-paciente.component.css'],
    standalone: true,
    imports: [RouterLink]
})
export class ListaPacienteComponent {

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
