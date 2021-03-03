import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ClienteService } from 'src/app/services/cliente.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { Cliente } from 'src/app/models/Cliente';
import { ToastrService } from 'ngx-toastr';
import { Endereco } from 'src/app/models/Endereco';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  clientes: any = [];
  cliente: Cliente = new Cliente();
  endereco: Endereco = new Endereco();
  dadosCliente: FormGroup;
  acaoExecutada: string;
  bodyRemoverCliente: string;

  constructor(
    private clienteService: ClienteService
    , private localeService: BsLocaleService
    , private toastr: ToastrService
    ) {
      this.localeService.use('pt-br')
    }

  ngOnInit(): void {
    this.listarTodosClientes();
  }

  openModal(template: any) {
    template.show();
  }

  listarTodosClientes(){
    this.clienteService.listarTodosClientes().subscribe(
      _clientes => {
        this.clientes = _clientes;
      }, error => {
        this.toastr.error(`Erro ao listar o(s) cliente(s): ${error}`);
      }
    );
  }

  removerCliente(cliente: Cliente, template: any) {
    this.openModal(template);
    this.cliente = cliente;
    this.bodyRemoverCliente = `Deseja remover o cliente: ${cliente.id} - ${cliente.nome}?`
  }

  confirmeRemove(template: any) {
    this.clienteService.removerCliente(this.cliente.id).subscribe(
      () => {
        template.hide();
        this.listarTodosClientes();
        this.toastr.success('Cliente removido com sucesso!');
      },
      error => {
        this.toastr.error(`Erro ao remover o cliente: ${error}`);
      }
    )
  }
}
