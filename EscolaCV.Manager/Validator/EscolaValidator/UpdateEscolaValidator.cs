using EscolaCV.Core.Share.DTOs.EscolaDto;
using FluentValidation;

namespace EscolaCV.Manager.Validator.EscolaValidator
{
    public class UpdateEscolaValidator : AbstractValidator<UpdateEscolaDto>
    {
        public UpdateEscolaValidator()
        {

            RuleFor(x => x.EscolaId)
                .NotNull()
                .NotEmpty()
                ;
        }
    }
}
