using FluentValidation.Results;
using SevenTech.Application.Validations;
using SevenTech.Application.ViewModels;
using System;

namespace SevenTech.Application.Commands
{
    /// <summary>
    /// Comando para adicionar um cliente
    /// </summary>
    public class AdicionaClienteCommand : Command
    {
        public DateTime DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }

        public AdicionaClienteCommand()
        {
            Id = new Random().Next();
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionaClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}