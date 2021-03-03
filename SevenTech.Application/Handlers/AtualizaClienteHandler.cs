using FluentValidation.Results;
using MediatR;
using SevenTech.Application.Commands;
using SevenTech.Domain.Enuns;
using SevenTech.Domain.Models;
using SevenTech.Domain.Repositories;
using SevenTech.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace SevenTech.Application.Handlers
{
    public class AtualizaClienteHandler : CommandHandler, IRequestHandler<AtualizaClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtualizaClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(AtualizaClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return request.ValidationResult;

            var cliente = await _clienteRepository.GetById(request.Id);

            if (cliente == null)
            {
                AdicionarErro("Cliente não existe.");
                return ValidationResult;
            }

            cliente.AtualizarInformacoes(CriarCliente(request));
            _clienteRepository.Update(cliente);

            return await PersistirDados(_unitOfWork);
        }

        /// <summary>
        /// Criar uma instancia da entidade de cliente
        /// </summary>
        /// <param name="request">requisição contendo os dados do cliente</param>
        /// <returns></returns>
        private Cliente CriarCliente(AtualizaClienteCommand request)
        {
            TipoSexo sexo = request.Sexo == 0 ? TipoSexo.Feminino : TipoSexo.Masculino;
            var cliente = new Cliente(request.Id, request.DataNascimento, request.Nome, sexo);
            cliente.AtribuirEndereco(new Endereco(request.Endereco.Id,
                                                  request.Endereco?.Bairro,
                                                  request.Endereco?.Cep,
                                                  request.Endereco.Cidade,
                                                  request.Id,
                                                  request.Endereco?.Complemento,
                                                  request.Endereco?.Estado,
                                                  request.Endereco?.Logradouro,
                                                  request.Endereco?.Numero));

            return cliente;
        }
    }
}