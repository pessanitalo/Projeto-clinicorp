import { Paciente } from './../models/paciente';
import { Consulta } from './../models/consulta';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsultaService } from '../services/consulta.service';
import { Medico } from '../models/medico';
import { parseDate } from '../services/parseDate';


@Component({
  selector: 'app-consulta-nova',
  templateUrl: './consulta-nova.component.html',
  styleUrls: ['./consulta-nova.component.css']
})
export class ConsultaNovaComponent implements OnInit {

  Form!: FormGroup;
  paciente!: FormGroup;
  
  consulta!: Consulta;

  medico!: Medico;
  nome!: string;
  errorMessage!: string;

  especializacao: string = "";

  constructor(
    private fb: FormBuilder,
    private consultaService: ConsultaService
  ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      dataConsulta: ['', [Validators.required]],
      descricaoConsulta: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
      
      paciente: this.fb.group({
        nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
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
     
    let dataConsulta = this.Form.get("dataConsulta")?.value;
    this.consulta.dataConsulta = parseDate(dataConsulta);

    let dataNascimento = this.Form.get("paciente.DataNascimento")?.value;
    this.consulta.paciente.DataNascimento = parseDate(dataNascimento);

    this.consulta.paciente.medicoId = this.medico.id;
    this.consultaService.addCliente(this.consulta)
      .subscribe(sucesso => { console.log(sucesso) },
        falha => { console.log(falha) }
      )
  }

  ErrorMessage(fieldName: string) {
    const field = this.Form.get(fieldName);

    if (field?.hasError('minlength')) {
      const requiredlength = field.errors ? field.errors['minlength']['requiredLength'] : null;
      return `Tamanho mínimo precisa ser de ${requiredlength} caracteres.`;
    }

    if (field?.hasError('maxlength')) {
      const requiredlength = field.errors ? field.errors['maxlength']['requiredLength'] : null;
      return `Tamanho máximo precisa ser de ${requiredlength} caracteres.`;
    }

    if (field?.touched || field?.dirty) {
      return 'campo obrigatório';
    }
    return ''
  }

}
