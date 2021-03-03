using MediatR;
using SevenTech.Application.Queries;
using SevenTech.Application.ViewModels;
using SevenTech.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SevenTech.Application.Handlers
{
    public class ListaTodosClientesHandler : IRequestHandler<ListaTodosClientesQuery, IEnumerable<ClienteViewModel>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ListaTodosClientesHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteViewModel>> Handle(ListaTodosClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteRepository.GetAll();

            if (!clientes.Any())
                return null;

            var clientesResult = clientes.Select(cliente => new ClienteViewModel
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
            });

            return clientesResult;
        }
    }
}