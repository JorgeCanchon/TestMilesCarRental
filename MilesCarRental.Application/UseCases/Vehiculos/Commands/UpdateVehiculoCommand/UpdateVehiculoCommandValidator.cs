﻿using FluentValidation;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.UpdateVehiculoCommand
{
    public class UpdateVehiculoCommandValidator : AbstractValidator<UpdateVehiculoCommand>
    {
        public UpdateVehiculoCommandValidator()
        {

            RuleFor(p => p.Id)
              .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
              .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.LocalidadDevolucionId)
              .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
              .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.Marca)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(150).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.Placa)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .MaximumLength(15).WithMessage("{PropertyName} no debe exceder de {MaxLength}");

            RuleFor(p => p.LocalidadDevolucionId)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");

            RuleFor(p => p.LocalidadRecogidaId)
               .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
               .GreaterThan(0).WithMessage("{PropertyName} debe ser numerico mayor a 0.");
        }
    }
}
