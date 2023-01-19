import { MedicoService } from './../services/medico.service';
import { Medico } from './../../consulta/models/medico';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-adicionar-medico',
  templateUrl: './adicionar-medico.component.html',
  styleUrls: ['./adicionar-medico.component.css']
})
export class AdicionarMedicoComponent implements OnInit {

  medico!: Medico;
  Form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private medicoService: MedicoService
  ) { }

  ngOnInit(): void {
    this.Form = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      cpf: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      crm: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      especializacao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
    });
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

  adicionar() {
    this.medico = Object.assign({}, this.medico, this.Form.value);
    this.medicoService.adicionar(this.medico)
      .subscribe(sucesso => { console.log(sucesso) },
        falha => { console.log(falha) }
      )
  }

}
