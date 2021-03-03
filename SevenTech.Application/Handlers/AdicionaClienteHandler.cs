using FluentValidation.Results;
using MediatR;
using SevenTech.Application.Commands;
using SevenTech.Domain.Enuns;
using SevenTech.Domain.Models;
using SevenTech.Domain.Repositories;
using SevenTech.Domain.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SevenTech.Application.Handlers
{
    /// <summary>
    /// Manipulador do comando de adicionar cliente
    /// </summary>
    public class AdicionaClienteHandler : CommandHandler, IRequestHandler<AdicionaClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdicionaClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Criar uma instancia da entidade de cliente
        /// </summary>
        /// <param name="request">requisição contendo os dados do cliente</param>
        /// <returns></returns>
        private Cliente CriarCliente(AdicionaClienteCommand request)
        {
            TipoSexo sexo = request.Sexo == 0 ? TipoSexo.Feminino : TipoSexo.Masculino;
            var cliente = new Cliente(request.Id, request.DataNascimento, request.Nome, sexo);
            cliente.AtribuirEndereco(new Endereco(new Random().Next(),
                                                  request.Endereco?.Bairro,
                                                  request.Endereco?.Cep,
                                                  request.Endereco?.Cidade,
                                                  request.Id,
                                                  request.Endereco?.Complemento,
                                                  request.Endereco?.Estado,
                                                  request.Endereco?.Logradouro,
                                                  request.Endereco?.Numero));

            return cliente;
        }

        public async Task<ValidationResult> Handle(AdicionaClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return request.ValidationResult;

            var clienteResult = await _clienteRepository.GetById(request.Id);

            if (clienteResult != null)
            {
                AdicionarErro("Cliente já cadastrado.");
                return ValidationResult;
            }

            _clienteRepository.Add(CriarCliente(request));

            return await PersistirDados(_unitOfWork);
        }
    }
}