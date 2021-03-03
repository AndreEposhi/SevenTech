using SevenTech.Domain.Enuns;
using System;

namespace SevenTech.Domain.Models
{
    /// <summary>
    /// Entidade de cliente
    /// </summary>
    public class Cliente : Entity
    {
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Nome { get; private set; }
        public TipoSexo Sexo { get; private set; }

        protected Cliente() { }
        public Cliente(int id, DateTime dataNascimento, string nome, TipoSexo tipoSexo) : base(id)
        {
            DataNascimento = dataNascimento;
            Nome = nome;
            Sexo = tipoSexo;
        }

        public void AtribuirEndereco(Endereco endereco)
         => Endereco = endereco;

        public void AtualizarInformacoes(Cliente cliente)
        {
            DataNascimento = cliente.DataNascimento;
            Nome = cliente.Nome;
            Sexo = cliente.Sexo;
            AtribuirEndereco(cliente.Endereco);
        }
    }
}