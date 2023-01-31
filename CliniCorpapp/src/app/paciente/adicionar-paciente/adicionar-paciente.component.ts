import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ConsultaService } from 'src/app/consulta/services/consulta.service';

@Component({
  selector: 'app-adicionar-paciente',
  templateUrl: './adicionar-paciente.component.html',
  styleUrls: ['./adicionar-paciente.component.css']
})
export class AdicionarPacienteComponent implements OnInit {

  Form!: FormGroup;

  
  constructor(
    private fb: FormBuilder,
    private consultaService: ConsultaService,
    private toastr: ToastrService,
    private router: Router,
    ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      DataNascimento: ['', [Validators.required]],
      email: ['', [Validators.required]],
    })
  }

}
