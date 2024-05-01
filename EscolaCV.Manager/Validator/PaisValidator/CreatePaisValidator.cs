using EscolaCV.Core.Share.DTOs.PaisDto;
using FluentValidation;

namespace EscolaCV.Manager.Validator.PaisValidator
{
    public class CreatePaisValidator:AbstractValidator<CreatePaisDto>
    {
        public CreatePaisValidator()
        {

            RuleFor(x => x.PaisId)
                        .NotNull().WithMessage("Por favor informe o código do país")
                        .NotEmpty().WithMessage("Por favor informe o código do país")
                        .MinimumLength(2).WithMessage("O código do país deve ter mais de 2 caracteres")
                        .MaximumLength(5).WithMessage("O código do país não deve exceder 5 caracteres");

            RuleFor(x => x.Nome)
                         .NotNull().WithMessage("Por favor informe o nome do país")
                         .NotEmpty().WithMessage("Por favor informe o nome do país")
                         .MinimumLength(2).WithMessage("O Nome do país deve ter mais de 2 caracteres")
                         .MaximumLength(100).WithMessage("O Nome do país não deve exceder 100 caracteres");

        }
    }
}
