import { editConsulta } from './../models/editarConsulta';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConsultaService } from '../services/consulta.service';
import { parseDate } from '../services/parseDate';

@Component({
  selector: 'app-consulta-detalhes',
  templateUrl: './consulta-detalhes.component.html',
  styleUrls: ['./consulta-detalhes.component.css']
})
export class ConsultaDetalhesComponent implements OnInit {


  public consulta: editConsulta;
  public date!: Date;

  public status!: number;

  constructor(
    private route: ActivatedRoute,
    private consultaService: ConsultaService) { this.consulta = this.route.snapshot.data['consulta'] }

  ngOnInit(): void {
  
  }

  updateStatus() {
    this.consultaService.update(this.consulta.id, this.status)
      .subscribe(sucesso => { console.log(sucesso) })
  }

  updateDate() {
    this.consultaService.updateDate(this.consulta.id, parseDate(this.date))
      .subscribe(sucesso => { console.log(sucesso) })
  }

}
