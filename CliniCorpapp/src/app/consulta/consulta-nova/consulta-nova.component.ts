import { Consulta } from './../models/consulta';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsultaService } from '../services/consulta.service';
import { Medico } from '../models/medico';

@Component({
  selector: 'app-consulta-nova',
  templateUrl: './consulta-nova.component.html',
  styleUrls: ['./consulta-nova.component.css']
})
export class ConsultaNovaComponent implements OnInit {

  Form!: FormGroup;
  consulta!: Consulta;

  medico!: Medico;
  nome!: string ;
  errorMessage!: string;

  especializacao: string = "";
  nomeMedico: string = "";


  constructor(
    private fb: FormBuilder,
    private consultaService: ConsultaService,
  ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      dataConsulta: ['', [Validators.required]],
      descricaoConsulta: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      // statusConsulta: ['', [Validators.required]],

      paciente: this.fb.group({
        nome: ['', [Validators.required]],
        cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
        DataNascimento: ['', [Validators.required]],
        email: ['', [Validators.required]],
      })
    });
  }

  buscarMedico() {
    this.consultaService.buscarMedicoPorNome(this.nome)
      .subscribe(res => this.medico = res,
        error => this.errorMessage
      )
  }

  adicionar() {
    this.consulta = Object.assign({}, this.consulta, this.Form.value);
    this.consulta.paciente.medicoId = this.medico.id;
    this.consultaService.addCliente(this.consulta)
      .subscribe(sucesso => { console.log(sucesso) },
        falha => { console.log(falha) }
      )
  }
}
