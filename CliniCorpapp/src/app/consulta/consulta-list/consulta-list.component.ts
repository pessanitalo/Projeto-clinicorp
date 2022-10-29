import { ConsultaService } from './../services/consulta.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Consulta } from '../models/consulta';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-consulta-list',
  templateUrl: './consulta-list.component.html',
  styleUrls: ['./consulta-list.component.css'],
  providers: [ConsultaService],
})
export class ConsultaListComponent implements OnInit {

  public consultas!: Consulta[];
  public consulta!: Consulta;

  public status!: number;
  public id!: number;

  public updates!: Date;

  errorMessage!: string;
  modalRef?: BsModalRef;

  constructor(
    private consultaService: ConsultaService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.consultaService.list().subscribe((res) => {
      this.consultas = res;
      for (let item of this.consultas) {
        if (item.statusConsulta === 0) {
          item.status = "Consulta Cancelada";
        }
        else {
          (item.statusConsulta === 1)
          item.status = "Consulta Finalizada";
        }
      }
    });
  }

  openModal(template: TemplateRef<any>, consulta: Consulta) {
    this.consultaService.detalhes(consulta.id).subscribe((res) => {
      this.consulta = res;
      this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    })
  }

  datemodal(template: TemplateRef<any>, id: number) {
    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    this.id = id;
  }

  updateStatus() {
    this.consultaService.update(this.status, this.id)
      .subscribe(sucesso => { console.log(sucesso) });
  }

  update(template: TemplateRef<any>, id: number) {
    this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    this.id = id;
  }

  click() {
    console.log(this.updates);
  }

}
