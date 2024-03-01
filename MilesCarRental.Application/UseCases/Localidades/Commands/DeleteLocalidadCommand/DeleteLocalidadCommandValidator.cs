using FluentValidation;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.DeleteLocalidadCommand
{
    public class DeleteLocalidadCommandValidator : AbstractValidator<DeleteLocalidadCommand>
    {
        public DeleteLocalidadCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
