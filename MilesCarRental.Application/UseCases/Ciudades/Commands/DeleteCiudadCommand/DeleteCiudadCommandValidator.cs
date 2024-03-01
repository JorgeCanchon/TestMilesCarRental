using FluentValidation;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.DeleteCiudadCommand
{
    public class DeleteCiudadCommandValidator : AbstractValidator<DeleteCiudadCommand>
    {
        public DeleteCiudadCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
