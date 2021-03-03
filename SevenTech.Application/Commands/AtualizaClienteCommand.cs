using SevenTech.Application.Validations;
using SevenTech.Application.ViewModels;
using System;

namespace SevenTech.Application.Commands
{
    public class AtualizaClienteCommand : Command
    {
        public DateTime DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }

        public AtualizaClienteCommand()
        { }

        public override bool EhValido()
        {
            ValidationResult = new AtualizaClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}