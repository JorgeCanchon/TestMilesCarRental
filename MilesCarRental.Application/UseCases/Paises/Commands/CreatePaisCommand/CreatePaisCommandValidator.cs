using FluentValidation;

namespace MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand
{
    public class CreatePaisCommandValidator : AbstractValidator<CreatePaisCommand>
    {
        public CreatePaisCommandValidator() 
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}");
        }
    }
}
