using SevenTech.Common.Enuns;
using SevenTech.Common.Extensions;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SevenTech.Common.Communications
{
    public class CustomResponse
    {
        public IList<object> Dados { get; private set; }

        public IList<string> Erros { get; private set; }

        public string Mensagem { get; set; }

        [JsonIgnore]
        public ResponseStatus Status { get; set; }

        public string StatusResposta { get => Status.GetDescription(); }

        public CustomResponse()
        {
            Erros = new List<string>();
            Dados = new List<object>();
        }

        public void AdicionarDado(IList<object> dados)
        {
            Dados.Clear();

            foreach (var dado in dados)
                Dados.Add(dado);
        }

        public void AdicionarErro(IList<string> erros)
        {
            Erros.Clear();

            foreach (var erro in erros)
                Erros.Add(erro);
        }
    }
}