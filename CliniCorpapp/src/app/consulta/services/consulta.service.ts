import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Consulta } from '../models/consulta';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ConsultaService {

  baseUrl = `${environment.mainUrlAPI}consulta`;

  constructor(private http: HttpClient) { }

  list(): Observable<Consulta[]> {
    return this.http.get<Consulta[]>(`${this.baseUrl}/list`);
  }

  detalhes(id: number): Observable<Consulta> {
    return this.http.get<Consulta>(`${this.baseUrl}/detalhes/${id}`);
  }

  edit(id: number): Observable<Consulta> {
    return this.http.get<Consulta>(`${this.baseUrl}/detalhes/${id}`);
  }

  update(id: number, status: number) {
    const param = {
      id: id,
      StatusConsulta: status
    }
    return this.http.put(`${this.baseUrl}/updatestatus`, param);
  }

  updateDate(id: number,  data: Date) {
    const param = {
      id: id,
      DataConsulta: data
    }
    return this.http.put(`${this.baseUrl}/updatedate`, param);
  }
}
