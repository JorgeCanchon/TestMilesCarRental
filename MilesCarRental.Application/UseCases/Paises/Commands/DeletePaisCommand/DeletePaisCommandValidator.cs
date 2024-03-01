using FluentValidation;

namespace MilesCarRental.Application.UseCases.Paises.Commands.DeletePaisCommand
{
    public class DeletePaisCommandValidator : AbstractValidator<DeletePaisCommand>
    {
        public DeletePaisCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
