import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { ClienteService } from 'src/app/services/cliente.service';
import { EnderecoService } from 'src/app/services/endereco.service';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { Cliente } from 'src/app/models/Cliente';
import { Endereco } from 'src/app/models/Endereco';
import { ActivatedRoute, Router } from '@angular/router';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-registrar-cliente',
  templateUrl: './registrar-cliente.component.html',
  styleUrls: ['./registrar-cliente.component.css']
})
export class RegistrarClienteComponent implements OnInit {

  clientes: any = [];
  cliente: Cliente = new Cliente();
  endereco: Endereco = new Endereco();
  dadosCliente: FormGroup;

  constructor(
    private clienteService: ClienteService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
    , private toastr: ToastrService
    , private enderecoService: EnderecoService
    , private router: ActivatedRoute
    , private route: Router
  ) {
    this.localeService.use('pt-br')
  }

  ngOnInit(): void {
    this.validation();
    this.popularCliente();
  }

  popularCliente() {
    const clienteId = +this.router.snapshot.paramMap.get('id');
    this.clienteService.obterClientePorId(clienteId).subscribe(
      (_cliente: Cliente) =>{
        this.cliente = Object.assign({}, _cliente);
        this.dadosCliente.patchValue(this.cliente);
      },
      error => {
        this.toastr.error(`Erro ao buscar o cliente: ${error}`);
      }
    );
  }

  obterEndereco(event: any) {
    let cep = event.target.value;
    cep = cep.replace('.','').replace('-','');

    if (cep.length < 8){
      this.toastr.error(`Cep inválido`);
      return;
    }

    this.enderecoService.obterEndereco(cep).subscribe(
      _endereco => {
        this.dadosCliente.patchValue({
          endereco: {
            bairro: _endereco.bairro,
            cidade: _endereco.cidade,
            complemento: _endereco.complemento,
            estado: _endereco.estado,
            logradouro: _endereco.logradouro
          }
        });
      },
      error => {
        this.toastr.error(`Erro ao obter o endereço do cep ${cep}: ${error}`);
      }
    );
  }

  validation(){
    this.dadosCliente = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      sexo: ['', Validators.required],
      endereco: this.criarEndereco()
    });
  }

  criarEndereco() : FormGroup{
    return this.fb.group({
      id: [''],
      bairro: ['', Validators.required],
      cep: ['', Validators.required],
      cidade: ['', Validators.required],
      complemento: [''],
      estado: ['', Validators.required],
      logradouro: ['', Validators.required],
      numero: ['', Validators.required],
      clienteId: ['']
    });
  }

  salvar() {
    if (this.dadosCliente.valid) {
      const id = +this.router.snapshot.paramMap.get('id');
      if (id <= 0) {
        let enderecoCliente = new Endereco();
        let novoCliente = new Cliente();

        enderecoCliente.bairro = this.dadosCliente.get('endereco.bairro').value;
        enderecoCliente.cep = this.dadosCliente.get('endereco.cep').value;
        enderecoCliente.logradouro = this.dadosCliente.get('endereco.logradouro').value;
        enderecoCliente.numero = this.dadosCliente.get('endereco.numero').value;
        enderecoCliente.cidade = this.dadosCliente.get('endereco.cidade').value;
        enderecoCliente.estado = this.dadosCliente.get('endereco.estado').value;
        enderecoCliente.complemento = this.dadosCliente.get('endereco.complemento').value;

        novoCliente.nome = this.dadosCliente.get('nome').value;
        novoCliente.dataNascimento = this.dadosCliente.get('dataNascimento').value;
        novoCliente.sexo = parseInt(this.dadosCliente.get('sexo').value);
        novoCliente.endereco = enderecoCliente;

        this.cliente = Object.assign({}, novoCliente);
        this.clienteService.adicionarCliente(this.cliente).subscribe(
          () =>{
            this.toastr.success('Cliente adicionado com sucesso!');
          },
          error =>{
            this.toastr.error(`Erro ao adicionar o cliente: ${error}`);
          });
      }
      else{

        let enderecoCliente = new Endereco();
        let clienteAtualizado = new Cliente();

        enderecoCliente.id = this.dadosCliente.get('endereco.id').value;
        enderecoCliente.bairro = this.dadosCliente.get('endereco.bairro').value;
        enderecoCliente.cep = this.dadosCliente.get('endereco.cep').value;
        enderecoCliente.logradouro = this.dadosCliente.get('endereco.logradouro').value;
        enderecoCliente.numero = this.dadosCliente.get('endereco.numero').value;
        enderecoCliente.cidade = this.dadosCliente.get('endereco.cidade').value;
        enderecoCliente.estado = this.dadosCliente.get('endereco.estado').value;
        enderecoCliente.complemento = this.dadosCliente.get('endereco.complemento').value;
        enderecoCliente.clienteId = this.dadosCliente.get('endereco.clienteId').value;

        clienteAtualizado.id = this.dadosCliente.get('id').value;
        clienteAtualizado.nome = this.dadosCliente.get('nome').value;
        clienteAtualizado.dataNascimento = new Date(this.dadosCliente.get('dataNascimento').value);
        clienteAtualizado.sexo = parseInt(this.dadosCliente.get('sexo').value);
        clienteAtualizado.endereco = enderecoCliente;

        this.cliente = Object.assign({id: clienteAtualizado.id}, clienteAtualizado);
        this.clienteService.atualizarCliente(this.cliente).subscribe(
          () =>{
            this.toastr.success('Cliente atualizado com sucesso!');
          },
          error =>{
            this.toastr.error(`Erro ao atualizar o cliente: ${error}`);
        });
      }
    }
  }
}
