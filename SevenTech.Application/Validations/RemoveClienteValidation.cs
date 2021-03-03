using SevenTech.Application.Commands;

namespace SevenTech.Application.Validations
{
    public class RemoveClienteValidation : Validation<RemoveClienteCommand>
    {
        public RemoveClienteValidation()
        {
            ValidarId();
        }
    }
}