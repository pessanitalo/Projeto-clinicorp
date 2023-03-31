import { Medico } from './../../consulta/models/medico';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {

  baseUrl = `${environment.mainUrlAPI}medico`;
  
  constructor(private http: HttpClient) { }

  list(): Observable<Medico[]> {
    return this.http.get<Medico[]>(`${this.baseUrl}/list`);
  }

  adicionar(medico: Medico) {
    return this.http.post<Medico>(this.baseUrl, medico);
  }

  buscarMedicoPorNome(nome: string): Observable<Medico> {
    return this.http.get<Medico>(`${this.baseUrl}/buscarmediconome/${nome}`);
  }
}
