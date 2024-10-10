import { MedicoService } from './../../medico/services/medico.service';
import { PacienteService } from './../../paciente/services/paciente.service';
import { Paciente } from './../models/paciente';
import { Consulta } from './../models/consulta';
import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ConsultaService } from '../services/consulta.service';
import { Medico } from '../models/medico';
import { parseDate } from '../services/parseDate';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-consulta-nova',
  templateUrl: './consulta-nova.component.html',
  styleUrls: ['./consulta-nova.component.css'],
  providers: [DatePipe]
})
export class ConsultaNovaComponent implements OnInit {

  Form!: UntypedFormGroup;

  consulta!: Consulta;
  medico!: Medico;

  paciente!: Paciente;
  nome!: string;


  errorMessage!: string;

  cpfPaciente!: string;

  constructor(
    private fb: UntypedFormBuilder,
    private consultaService: ConsultaService,
    private pacienteService: PacienteService,
    private medicoService: MedicoService,
    private toastr: ToastrService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      dataConsulta: ['', [Validators.required]],
      descricaoConsulta: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
    });
  }

  buscarMedico() {
    if(this.nome == null || this.nome.length <= 0){
      this.toastr.warning('Campo Médico Obrigatório', 'Ops!');
    }
    else{
      this.medicoService.buscarMedicoPorNome(this.nome).subscribe((res) => {
        this.medico = res;
        this.Sucesso(res)
      },
        falha => { this.processarFalha(falha) }
      )
    }
    
  }


  buscarPaciente() {
    if(this.cpfPaciente == null || this.cpfPaciente.length <= 0){
      this.toastr.warning('Campo Paciente Obrigatório', 'Ops!');
    }
    else{
      this.pacienteService.buscarpacientePorNome(this.cpfPaciente).subscribe((res) => {
        this.paciente = res;
        this.toastr.success('Paciente adicionado com sucesso.', 'Sucesso!');
      },
        falha => { this.processarFalha(falha) }
      )
    }
 
  }

  adicionar() {
    this.consulta = Object.assign({}, this.consulta, this.Form.value);

    let dataConsulta = this.Form.get("dataConsulta")?.value;
    this.consulta.dataConsulta = parseDate(dataConsulta);

    this.consulta.medicoId = this.medico.id;
    console.log(this.consulta.medicoId);
    this.consulta.pacienteId = this.paciente.id;
    
    this.consultaService.addCliente(this.consulta).subscribe(sucesso => {
      this.processarSucesso(sucesso)
    },
      falha => { this.processarFalha(falha) }
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

  processarSucesso(response: any) {
    this.Form.reset();
    let toast = this.toastr.success('Consulta Agendada', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/consultalist'])
      });
    }
  }

  Sucesso(response: any) {
    this.toastr.success('Médico Adicionado', 'Sucesso!');
  }

  processarFalha(fail: any) {
    this.toastr.error(fail.error, 'Error!');
  }

}
