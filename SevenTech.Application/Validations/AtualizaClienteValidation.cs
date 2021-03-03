using FluentValidation;
using SevenTech.Application.Commands;
using System;

namespace SevenTech.Application.Validations
{
    public class AtualizaClienteValidation : Validation<AtualizaClienteCommand>
    {
        public AtualizaClienteValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarDataNascimento();
            ValidarSexo();
            ValidarBairro();
            ValidarCidade();
            ValidarCep();
            ValidarEstado();
            ValidarLogradouro();
            ValidarNumero();
        }

        protected void ValidarBairro()
        {
            RuleFor(r => r.Endereco.Bairro)
                .NotEmpty().WithMessage("Bairro é obrigatório.");
        }

        protected void ValidarCep()
        {
            RuleFor(r => r.Endereco.Cep)
                .NotEmpty().WithMessage("Cep é obrigatório.");
        }

        protected void ValidarCidade()
        {
            RuleFor(r => r.Endereco.Cidade)
                .NotEmpty().WithMessage("Cdiade é obrigatório.");
        }

        protected void ValidarDataNascimento()
        {
            RuleFor(r => r.DataNascimento)
                .InclusiveBetween(DateTime.MinValue, DateTime.Now.Date)
                .WithMessage("Data de nascimento é inválida.");
        }

        protected void ValidarEstado()
        {
            RuleFor(r => r.Endereco.Estado)
                .NotEmpty().WithMessage("Estado é obrigatório.");
        }

        protected void ValidarLogradouro()
        {
            RuleFor(r => r.Endereco.Logradouro)
                .NotEmpty().WithMessage("Logradouro é obrigatório.");
        }

        protected void ValidarNome()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .Length(2, 200).WithMessage("Nome deve conter no mímimo 2 letras e no máximo 200.");
        }

        protected void ValidarNumero()
        {
            RuleFor(r => r.Endereco.Numero)
                .NotEmpty().WithMessage("Número é obrigatório.");
        }

        protected void ValidarSexo()
        {
            RuleFor(r => r.Sexo).InclusiveBetween(0, 1).WithMessage("Sexo é obrigatório.");
        }
    }
}