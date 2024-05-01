using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using FluentValidation;

namespace EscolaCV.Manager.Validator.ProvinciaValidator
{
    public class CreateProvinciaValidator:AbstractValidator<CreateProvinciaDto>
    {
        public CreateProvinciaValidator()
        {
            RuleFor(x => x.PaisId)
            .NotNull().WithMessage("Por favor informe o código do país")
            .NotEmpty().WithMessage("Por favor informe o código do país")
            .MinimumLength(2).WithMessage("O código do país deve ter mais de 2 caracteres")
            .MaximumLength(5).WithMessage("O código do país não deve exceder 5 caracteres");

            RuleFor(x => x.Nome)
                         .NotNull().WithMessage("Por favor informe o nome da província")
                         .NotEmpty().WithMessage("Por favor informe o nome da província")
                         .MinimumLength(2).WithMessage("O Nome da província deve ter mais de 2 caracteres")
                         .MaximumLength(100).WithMessage("O Nome da província não deve exceder 100 caracteres"); 
            
            RuleFor(x => x.Capital)
                         .NotNull().WithMessage("Por favor informe a capital da província")
                         .NotEmpty().WithMessage("Por favor informe a capital da província")
                         .MinimumLength(2).WithMessage("O Nome da capital da província deve ter mais de 2 caracteres")
                         .MaximumLength(100).WithMessage("O Nome da capital da província não deve exceder 100 caracteres");
        }
    }
}
