using EscolaCV.Core.Share.DTOs.EscolaDto;
using EscolaCV.Manager.ValuesObjects;

namespace EscolaCV.Manager.Interfaces.IEscola
{
    public interface IEscolaManager : IBaseManager<Response>, IRequestBase<CreateEscolaDto, UpdateEscolaDto>
    {
        Task<Response> CreateEscolasAsync(IEnumerable<ExcelEscolaDto> collection);

    }
}
