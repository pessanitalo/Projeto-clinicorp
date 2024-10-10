import { editConsulta } from '../models/editarConsulta';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ConsultaService } from '../services/consulta.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-consulta-detalhes',
    templateUrl: './consulta-remarcar.component.html',
    styleUrls: ['./consulta-remarcar.component.css'],
    standalone: true,
    imports: [RouterLink, FormsModule]
})
export class ConsultaDetalhesComponent implements OnInit {

  public consulta: editConsulta;
  public date!: Date;

  public status!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private consultaService: ConsultaService) { this.consulta = this.route.snapshot.data['consulta'] }

  ngOnInit(): void {}

  updateDate() {
    if(this.date == null){
      alert("Campo Data Obrigatório");
    }
    // this.consultaService.remarcar(this.consulta.id, parseDate(this.date))
    //   .subscribe(sucesso => { this.processarSucesso(sucesso) })
  }

  return(){
    this.router.navigate(["/consultalist"]);
  }

  processarSucesso(response: any) {
    let toast = this.toastr.success('Consulta Remarcada', 'Sucesso!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/consultalist'])
      });
    }
  }

  processarFalha(fail: any) {
    this.toastr.error(fail.error, 'Error!');
  }

}
