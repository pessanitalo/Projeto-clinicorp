import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Consulta } from "../models/consulta";
import { ConsultaService } from "./consulta.service";


@Injectable()
export class ConsultaResolve implements Resolve<Consulta>{

    constructor(private consultaService: ConsultaService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.consultaService.detalhes(route.params['id']);
    }
}
