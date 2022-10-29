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
    return this.http.get<Consulta[]>(`${this.baseUrl}/get`);
  }

  detalhes(id: number): Observable<Consulta> {
    return this.http.get<Consulta>(`${this.baseUrl}/detalhes/${id}`);
  }

  update(param: number, id: number) {
    const status = {
      id: id,
      status: param
    }
    return this.http.put(`${this.baseUrl}/updatestatus`, status);
  }


}
