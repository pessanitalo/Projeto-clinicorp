import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Paciente } from 'src/app/consulta/models/paciente';
import { parseDate } from 'src/app/utils/utils';
import { PacienteService } from '../services/paciente.service';

@Component({
  selector: 'app-adicionar-paciente',
  templateUrl: './adicionar-paciente.component.html',
  styleUrls: ['./adicionar-paciente.component.css']
})
export class AdicionarPacienteComponent implements OnInit {

  Form!: UntypedFormGroup;

  paciente!: Paciente;

  
  constructor(
    private fb: UntypedFormBuilder,
    private pacienteService: PacienteService,
    private toastr: ToastrService,
    private router: Router,
    ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      dataNascimento: ['', [Validators.required]],
      email: ['', [Validators.required]],
    })
  }


  adicionar() {
    this.paciente = Object.assign({}, this.paciente, this.Form.value);

    let datapaciente = this.Form.get("dataNascimento")?.value;  
    this.paciente.dataNascimento = parseDate(datapaciente);

    this.pacienteService.adicionar(this.paciente)
      .subscribe(sucesso => { this.processarSucesso(sucesso) },
        falha => { this.processarFalha(falha) }
      )
  }

  processarSucesso(response: any) {
    this.Form.reset();
    let toast = this.toastr.success('Paciente cadastrado', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/lista'])
      });
    }
  }

  processarFalha(fail: any) {
    this.toastr.error( fail.error, 'Error!' );
   }

}
