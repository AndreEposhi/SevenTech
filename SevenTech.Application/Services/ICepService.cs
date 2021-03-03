using SevenTech.Application.ViewModels;
using SevenTech.Common.Communications;
using System.Threading.Tasks;

namespace SevenTech.Application.Services
{
    /// <summary>
    /// Interface do serviço de consulta de cep
    /// </summary>
    public interface ICepService
    {
        /// <summary>
        /// Url do serviço ViaCep
        /// </summary>
        string ViaCepUrl { get; }

        /// <summary>
        /// Otem o endereço de acordo com o cep pesquisado no serviço ViaCep
        /// </summary>
        /// <param name="cep">Cep a ser pesquisado</param>
        /// <returns></returns>
        Task<EnderecoViewModel> ObterEndereco(string cep);
    }
}