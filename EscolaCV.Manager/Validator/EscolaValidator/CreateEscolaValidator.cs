using EscolaCV.Core.Share.DTOs.EscolaDto;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EscolaCV.Manager.Validator.EscolaValidator
{
    public class CreateEscolaValidator : AbstractValidator<CreateEscolaDto>
    {
        public CreateEscolaValidator()
        {
            RuleFor(x => x.Nome)
                         .NotNull().WithMessage("Por favor informe o nome da escola")
                         .NotEmpty().WithMessage("Por favor informe o nome da escola")
                         .MinimumLength(5).WithMessage("O Nome da escola deve ter mais de 5 caracteres")
                         .MaximumLength(200).WithMessage("O Nome da escola não deve exceder 200 caracteres");

            RuleFor(x => x.Email)
                         .NotNull().WithMessage("Por Digite um email válido")
                         .NotEmpty().WithMessage("Por Digite um email válido")
                         .EmailAddress().WithMessage("Formato de email inválido.")
                         .Must(BeValidEmail).WithMessage("Formato de email inválido.");

            RuleFor(x => x.Provincia)
               .NotNull().WithMessage("Por favor informe a província")
                  .NotEmpty().WithMessage("Por favor informe a província")
                 .MinimumLength(5).WithMessage("O Nome da província deve ter mais de 2 caracteres")
                 .MaximumLength(200).WithMessage("O Nome da província não deve exceder 100 caracteres");


            RuleFor(x => x.NumSalas)
                         .NotNull().WithMessage("Por favor informe o número de salas")
                         .NotEmpty().WithMessage("Por favor informe o número de salas");
        }

        private bool BeValidEmail(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

    }
}
