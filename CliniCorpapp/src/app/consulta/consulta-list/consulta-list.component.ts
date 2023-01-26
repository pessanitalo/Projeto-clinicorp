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

  public id!: number;

  errorMessage!: string;
  modalRef?: BsModalRef;

  numero!: number;
  status!: string;
  statusConsulta: any;

  constructor(
    private consultaService: ConsultaService,
    private modalService: BsModalService,
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
      console.log(this.consulta);
      this.modalRef = this.modalService.show(template, { class: 'modal-lg' });
    })
  }

  updateStatus(id: number) {
    console.log(id);
    this.consultaService.update(id)
      .subscribe(sucesso => { console.log(sucesso) })
  }

}
