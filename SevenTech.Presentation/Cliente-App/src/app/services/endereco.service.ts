import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endereco } from '../models/Endereco';

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {

  constructor(private http: HttpClient) { }

  obterEndereco(cep: string) : Observable<Endereco> {
    return this.http.get<Endereco>(`https://localhost:44359/api/endereco/ObterEndereco/${cep}`)
  }
}
