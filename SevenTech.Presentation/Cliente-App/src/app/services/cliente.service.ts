import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  baseUrl = 'https://localhost:44359/api/cliente';

  constructor(private http: HttpClient) { }

  listarTodosClientes() : Observable<Cliente[]>{
    return this.http.get<Cliente[]>(`${this.baseUrl}/ListarTodosClientes`);
  }

  obterClientePorId(id: number) : Observable<Cliente> {
   return this.http.get<Cliente>(`${this.baseUrl}/ObterClientePorId/${id}`);
  }

   adicionarCliente(cliente: Cliente) {
     return this.http.post(`${this.baseUrl}/AdicionarCliente`, cliente);
   }

   atualizarCliente(cliente: Cliente) {
     return this.http.put(`${this.baseUrl}/AtualizarCliente`, cliente)
   }

   removerCliente(id: number) {
     return this.http.delete(`${this.baseUrl}/RemoverCliente/${id}`);
   }
}
