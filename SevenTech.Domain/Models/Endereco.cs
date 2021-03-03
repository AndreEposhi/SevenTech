namespace SevenTech.Domain.Models
{
    /// <summary>
    /// Entidade de endereço
    /// </summary>
    public class Endereco : Entity
    {
        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public string Cidade { get; private set; }

        public Cliente Cliente { get; protected set; }

        public int ClienteId { get; private set; }

        public string Complemento { get; private set; }

        public string Estado { get; private set; }

        public string Logradouro { get; private set; }

        public string Numero { get; private set; }

        protected Endereco()
        {
        }

        public Endereco(int id, string bairro, string cep, string cidade, int clienteId, string complemento, string estado, string logradouro, string numero) : base(id)
        {
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            ClienteId = clienteId;
            Complemento = complemento;
            Estado = estado;
            Logradouro = logradouro;
            Numero = numero;
        }
    }
}