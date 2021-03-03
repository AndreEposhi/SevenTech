using MediatR;
using SevenTech.Application.ViewModels;

namespace SevenTech.Application.Queries
{
    public class ObterClientePorIdQuery : IRequest<ClienteViewModel>
    {
        public int Id { get; set; }

        public ObterClientePorIdQuery(int id)
        {
            Id = id;
        }
    }
}