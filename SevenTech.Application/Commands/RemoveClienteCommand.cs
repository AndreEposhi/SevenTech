using SevenTech.Application.Validations;

namespace SevenTech.Application.Commands
{
    public class RemoveClienteCommand : Command
    {
        public RemoveClienteCommand(int id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoveClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}