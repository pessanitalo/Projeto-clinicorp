import { Consulta } from './../models/consulta';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-consulta-nova',
  templateUrl: './consulta-nova.component.html',
  styleUrls: ['./consulta-nova.component.css']
})
export class ConsultaNovaComponent implements OnInit {

  Form!: FormGroup;
  consulta!: Consulta;

  constructor(
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      dataConsulta: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      descricaoConsulta: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      statusConsulta: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],

      paciente: this.fb.group({
        nome: ['', [Validators.required]],
        cpf: ['', [Validators.required]],
        DataNascimento: ['', [Validators.required]],
        email:['', [Validators.required]],
      })
    });
  }

  adicionar() {

  }
}
