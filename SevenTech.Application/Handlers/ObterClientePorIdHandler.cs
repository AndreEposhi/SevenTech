using MediatR;
using SevenTech.Application.Queries;
using SevenTech.Application.ViewModels;
using SevenTech.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SevenTech.Application.Handlers
{
    public class ObterClientePorIdHandler : IRequestHandler<ObterClientePorIdQuery, ClienteViewModel>
    {
        private readonly IClienteRepository _ClienteRepository;

        public ObterClientePorIdHandler(IClienteRepository clienteRepository)
        {
            _ClienteRepository = clienteRepository;
        }

        public async Task<ClienteViewModel> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _ClienteRepository.GetById(request.Id);

            if (cliente == null)
                return null;

            return new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                DataNascimento = cliente.DataNascimento.ToString("MM/dd/yyyy"),
                Sexo = (int)cliente.Sexo,
                Endereco = new EnderecoViewModel
                {
                    Id = cliente.Endereco == null ? 0 : cliente.Endereco.Id,
                    Bairro = cliente.Endereco?.Bairro,
                    Cep = cliente.Endereco?.Cep,
                    Cidade = cliente.Endereco?.Cidade,
                    Estado = cliente.Endereco?.Estado,
                    Complemento = cliente.Endereco?.Complemento,
                    ClienteId = cliente.Endereco == null ? 0 : cliente.Endereco.ClienteId,
                    Logradouro = cliente.Endereco?.Logradouro,
                    Numero = cliente.Endereco?.Numero
                }
            };
        }
    }
}