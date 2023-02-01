import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Paciente } from 'src/app/consulta/models/paciente';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  baseUrl = `${environment.mainUrlAPI}paciente`;

  constructor(private http: HttpClient) { }

  buscarpacientePorNome(nome: string): Observable<Paciente> {
    return this.http.get<Paciente>(`${this.baseUrl}/pesquisarpaciente/${nome}`);
  }
}
