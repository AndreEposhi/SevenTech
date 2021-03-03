using Microsoft.AspNetCore.Mvc;
using SevenTech.Application.Services;
using System.Threading.Tasks;

namespace SevenTech.Api.Controllers
{
    [Route("api/endereco")]
    /// <summary>
    /// Controlador do endereço
    /// </summary>
    public class EnderecoController : MainController
    {
        private ICepService _cepService;

        public EnderecoController(ICepService cepService)
        {
            _cepService = cepService;
        }

        /// <summary>
        /// Otem o endereço de acordo com o cep pesquisado no serviço ViaCep
        /// </summary>
        /// <param name="cep">Cep a ser pesquisado</param>
        /// <returns></returns>
        [HttpGet("ObterEndereco/{cep}")]
        public async Task<IActionResult> ObterEndereco(string cep)
            => CustomResponse(await _cepService.ObterEndereco(cep));
    }
}