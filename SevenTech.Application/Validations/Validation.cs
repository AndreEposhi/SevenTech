using FluentValidation;
using SevenTech.Application.Commands;

namespace SevenTech.Application.Validations
{
    /// <summary>
    /// Validação das entidade
    /// </summary>
    /// <typeparam name="T">Validações do tipo Command</typeparam>
    public abstract class Validation<T> : AbstractValidator<T>
        where T : Command
    {
        protected void ValidarId()
        {
            RuleFor(r => r.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Identificador inválido.");
        }
    }
}