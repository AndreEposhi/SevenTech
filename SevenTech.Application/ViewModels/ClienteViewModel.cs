using System;

namespace SevenTech.Application.ViewModels
{
    public class ClienteViewModel
    {
        public string DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
    }
}