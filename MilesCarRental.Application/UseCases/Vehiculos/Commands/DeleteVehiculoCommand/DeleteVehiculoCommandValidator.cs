using FluentValidation;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.DeleteVehiculoCommand
{
    public class DeleteVehiculoCommandValidator : AbstractValidator<DeleteVehiculoCommand>
    {
        public DeleteVehiculoCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
