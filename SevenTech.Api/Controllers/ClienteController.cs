using MediatR;
using Microsoft.AspNetCore.Mvc;
using SevenTech.Application.Commands;
using SevenTech.Application.Queries;
using System.Threading.Tasks;

namespace SevenTech.Api.Controllers
{
    [Route("api/cliente")]
    /// <summary>
    /// Controlador do cliente
    /// </summary>
    public class ClienteController : MainController
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adiciona um cliente no banco de dados
        /// </summary>
        /// <param name="request">Requisição contendo os dados do cliente</param>
        /// <returns></returns>
        [HttpPost("AdicionarCliente")]
        public async Task<IActionResult> AdicionarCliente([FromBody] AdicionaClienteCommand request)
            => CustomResponse(await _mediator.Send(request));

        /// <summary>
        /// Atualiza os dados do cliente no banco de dados
        /// </summary>
        /// <param name="request">Requisição contendo os dados do cliente</param>
        /// <returns></returns>
        [HttpPut("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente([FromBody] AtualizaClienteCommand request)
            => CustomResponse(await _mediator.Send(request));
        /// <summary>
        /// Remove um cliente do banco de dados
        /// </summary>
        /// <param name="id">Identificador do cliente a ser removido</param>
        /// <returns></returns>
        [HttpDelete("RemoverCliente/{id}")]
        public async Task<IActionResult> RemoverCliente(int id)
            => CustomResponse(await _mediator.Send(new RemoveClienteCommand(id)));
        /// <summary>
        /// Lista todos os clientes do banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListarTodosClientes")]
        public async Task<IActionResult> ListarTodosClientes()
            => CustomResponse(await _mediator.Send(new ListaTodosClientesQuery()));
        /// <summary>
        /// Obtem um cliente do banco de dados de acordo com o identificador
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        [HttpGet("ObterClientePorId/{id}")]
        public async Task<IActionResult> ObterClientePorId(int id)
            => CustomResponse(await _mediator.Send(new ObterClientePorIdQuery(id)));
    }
}