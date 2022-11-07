import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Consulta } from '../models/consulta';
import { ConsultaService } from '../services/consulta.service';

@Component({
  selector: 'app-consulta-detalhes',
  templateUrl: './consulta-detalhes.component.html',
  styleUrls: ['./consulta-detalhes.component.css']
})
export class ConsultaDetalhesComponent implements OnInit {

  public consulta!: Consulta;
  public dataConsulta!: string;

  public status!: number;

  constructor(
    private route: ActivatedRoute,
    private consultaService: ConsultaService) { this.consulta = this.route.snapshot.data['consulta'] }



  ngOnInit(): void {
  }

  // dataAtualiza() {
  //   this.consultaService.dataAtualiza(this.dataConsulta)
  //     .subscribe(sucesso => { console.log(sucesso) })
  // }

  click(){
    console.log('data :', this.dataConsulta);
  }

  updateStatus() {
    console.log('status :', this.dataConsulta);
    this.consultaService.update(this.consulta.id, this.status)
      .subscribe(sucesso => { console.log(sucesso) })
  }

}
