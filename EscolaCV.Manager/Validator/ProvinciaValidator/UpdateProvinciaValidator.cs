using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using FluentValidation;

namespace EscolaCV.Manager.Validator.ProvinciaValidator
{
    public class UpdateProvinciaValidator: AbstractValidator<UpdateProvinciaDto>
    {
        public UpdateProvinciaValidator()
        {

            RuleFor(x => x.ProvinciaId)
            .NotNull().WithMessage("Por favor informe o código da província")
            .NotEmpty().WithMessage("Por favor informe o código da província")
            ;

        }
    }
}
