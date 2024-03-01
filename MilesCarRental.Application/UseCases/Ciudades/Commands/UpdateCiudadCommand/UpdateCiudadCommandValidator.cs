using FluentValidation;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.UpdateCiudadCommand
{
    public class UpdateCiudadCommandValidator : AbstractValidator<UpdateCiudadCommand>
    {
        public UpdateCiudadCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.PaisId)
              .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
              .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}");
        }
    }
}
