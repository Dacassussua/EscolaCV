using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using EscolaCV.Manager.Interfaces;
using EscolaCV.Manager.ValuesObjects;
using Microsoft.AspNetCore.Http;

namespace ProvinciaCV.Manager.Interfaces.IProvincia
{
    public interface IProvinciaManager : IBaseManager<Response>, IRequestBase<CreateProvinciaDto, UpdateProvinciaDto>
    {
        Task<Response> CreateProvincesAsync(IFormFile JsonFile);
    }
}
