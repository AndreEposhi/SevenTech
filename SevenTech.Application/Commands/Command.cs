using FluentValidation.Results;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace SevenTech.Application.Commands
{
    /// <summary>
    /// Comando base das entidades
    /// </summary>
    public abstract class Command : IRequest<ValidationResult>
    {
        public DateTime DataCadastro { get; private set; }
        public int Id { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            DataCadastro = DateTime.Now.Date;
        }

        public abstract bool EhValido();
    }
}