import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Consulta } from "../models/consulta";
import { ConsultaService } from "./consulta.service";


@Injectable()
export class ConsultaResolve implements Resolve<Consulta>{

    constructor(private consultaService: ConsultaService) { }

    //mudar a rota para detalhes para funcionar o edit
    resolve(route: ActivatedRouteSnapshot) {
        return this.consultaService.edit(route.params['id']);
    }
}
