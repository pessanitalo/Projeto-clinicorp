import { editConsulta } from './../models/editarConsulta';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    private router: Router,
    private consultaService: ConsultaService) { this.consulta = this.route.snapshot.data['consulta'] }

  ngOnInit(): void {
  
  }

  updateStatus() {
    this.consultaService.update(this.consulta.id)
      .subscribe(sucesso => { console.log(sucesso) })
  }

  updateDate() {
    if(this.date == null){
      alert("Campo Data Obrigatório");
    }
    this.consultaService.updateDate(this.consulta.id, parseDate(this.date))
      .subscribe(sucesso => { console.log(sucesso) })
  }

  return(){
    this.router.navigate(["/consultalist"]);
  }

}
