import { ConsultaService } from './../services/consulta.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Consulta } from '../models/consulta';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-consulta-list',
  templateUrl: './consulta-list.component.html',
  styleUrls: ['./consulta-list.component.css'],
  providers: [ConsultaService],
})
export class ConsultaListComponent implements OnInit {

  public consultas!: Consulta[];
  public consulta!: Consulta;

  public id!: number;
  public template!: TemplateRef<any>;

  errorMessage!: string;
  modalRef?: BsModalRef;

  numero!: number;
  status!: string;
  statusConsulta: any;

  constructor(
    private consultaService: ConsultaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.consultaService.list().subscribe((res) => {
      this.consultas = res;
    });
  }

  openModal(template: TemplateRef<any>, consulta: Consulta) {
    this.consultaService.detalhes(consulta.id).subscribe((res) => {
      this.consulta = res;
      this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    })
  }

  cancell(template: TemplateRef<any>, consulta: Consulta) {
    this.consultaService.detalhes(consulta.id).subscribe((res) => {
      this.consulta = res;
      console.log(this.consulta);
      this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    })
  }

  cancelarConsulta() {
    this.consultaService.calcelar(this.consulta.id)
      .subscribe(sucesso => { this.processarSucesso(sucesso) })
  }

  processarSucesso(response: any) {
    let toast = this.toastr.success('Consulta Cancelada', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.modalService.hide();
      });
    }
  }

}
