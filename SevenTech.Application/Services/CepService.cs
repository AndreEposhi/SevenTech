using SevenTech.Application.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SevenTech.Application.Services
{
    public class CepService : ICepService
    {
        public string ViaCepUrl => "https://viacep.com.br/ws/";

        /// <summary>
        /// Remove todos os caracteres do cep, deixando apenas os números
        /// </summary>
        /// <param name="cep">Cep a ser removido os caracteres</param>
        /// <returns></returns>
        private int SomenteNumerosDoCep(string cep)
            => Convert.ToInt32(cep.Replace(".", "").Replace("-", ""));

        public async Task<EnderecoViewModel> ObterEndereco(string cep)
        {
            var cepResult = SomenteNumerosDoCep(cep);
            var request = WebRequest.CreateHttp($"{ViaCepUrl}{cepResult}/json/");
            var cepDeserialize = new CepDeserialize();

            request.Method = "GET";

            using (var response = await request.GetResponseAsync())
            {
                var responseStream = response.GetResponseStream();
                var reader = new StreamReader(responseStream);
                object objectResponse = await reader.ReadToEndAsync();
                cepDeserialize = JsonSerializer.Deserialize<CepDeserialize>(objectResponse.ToString());
            }

            if (cepDeserialize == null)
                return null;

            return new EnderecoViewModel
            {
                Bairro = cepDeserialize.Bairro,
                Cep = cepDeserialize.Cep,
                Cidade = cepDeserialize.Localidade,
                Complemento = cepDeserialize.Complemento,
                Estado = cepDeserialize.Uf,
                Logradouro = cepDeserialize.Logradouro
            };
        }
    }
}