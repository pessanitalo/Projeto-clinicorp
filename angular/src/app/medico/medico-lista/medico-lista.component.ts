import { Component, OnInit } from '@angular/core';
import { Medico } from 'src/app/consulta/models/medico';
import { MedicoService } from '../services/medico.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-medico-lista',
  templateUrl: './medico-lista.component.html',
  styleUrls: ['./medico-lista.component.css'],
  standalone: true,
  imports: [RouterLink]
})
export class MedicoListaComponent implements OnInit {

  constructor(
    private medicoService: MedicoService,
  ) { }

  medicos!: Medico[];

  ngOnInit(): void {
    this.list();
  }

  list() {
    this.medicoService.list().subscribe(
      medicos => this.medicos = medicos,
      error => (console.log(error))
    );
  }

}
