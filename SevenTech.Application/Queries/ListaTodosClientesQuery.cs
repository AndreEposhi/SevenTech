using MediatR;
using SevenTech.Application.ViewModels;
using System.Collections.Generic;

namespace SevenTech.Application.Queries
{
    public class ListaTodosClientesQuery : IRequest<IEnumerable<ClienteViewModel>>
    {
    }
}