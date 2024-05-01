using EscolaCV.Core.Share.DTOs.PaisDto;
using EscolaCV.Manager.ValuesObjects;

namespace EscolaCV.Manager.Interfaces.IPais
{
    public interface IPaisManager : IBaseManager<Response>, IRequestBase<CreatePaisDto, UpdatePaisDto>
    {

    }
}
