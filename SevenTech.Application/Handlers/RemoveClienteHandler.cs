using FluentValidation.Results;
using MediatR;
using SevenTech.Application.Commands;
using SevenTech.Domain.Repositories;
using SevenTech.Domain.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace SevenTech.Application.Handlers
{
    public class RemoveClienteHandler : CommandHandler, IRequestHandler<RemoveClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido())
                return request.ValidationResult;

            var cliente = await _clienteRepository.GetById(request.Id);

            if (cliente == null)
            {
                AdicionarErro("Cliente não existe.");
                return ValidationResult;
            }

            _clienteRepository.Delete(cliente);

            return await PersistirDados(_unitOfWork);
        }
    }
}