using Backend.Dtos;
using FluentValidation;

namespace Backend.Validators
{
    public class SucursalValidator : AbstractValidator<SucursalDto>
    {
        public SucursalValidator()
        {
            RuleFor(s => s.Nombre).NotEmpty().WithMessage("El nombre de la sucursal es requerido");
            RuleFor(s => s.Ciudad).NotEmpty().WithMessage("La ciudad de la sucursal es requerida");
            RuleFor(s => s.Telefono).NotEmpty().WithMessage("El teléfono de la sucursal es requerido");
            RuleFor(s => s.NombreTitular).NotEmpty().WithMessage("El nombre del titular de la sucursal es requerido");
            RuleFor(s => s.ApellidoTitular).NotEmpty().WithMessage("El apellido del titular de la sucursal es requerido");
            RuleFor(s => s.TipoId).NotEqual(Guid.Empty).WithMessage("El tipo de la sucursal es requerido");
            RuleFor(s => s.ProvinciaId).NotEqual(Guid.Empty).WithMessage("La provincia de la sucursal es requerida");
        }
    }
}
