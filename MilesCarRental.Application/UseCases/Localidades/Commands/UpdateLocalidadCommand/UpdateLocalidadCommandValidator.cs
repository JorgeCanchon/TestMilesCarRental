using FluentValidation;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.UpdateLocalidadCommand
{
    public class UpdateLocalidadCommandValidator : AbstractValidator<UpdateLocalidadCommand>
    {
        public UpdateLocalidadCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.CiudadId)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
