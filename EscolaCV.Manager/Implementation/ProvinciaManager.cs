using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using EscolaCV.Manager.Implementation;
using EscolaCV.Manager.Interfaces.IProvincia;
using EscolaCV.Manager.ValuesObjects;
using Microsoft.AspNetCore.Http;
using ProvinciaCV.Manager.Interfaces.IProvincia;

namespace ProvinciaCV.Manager.Implementation
{
    public class ProvinciaManager : IProvinciaManager
    {
        private readonly IProvinciaRepository _repository;
        private readonly IMapper _mapper;

        public ProvinciaManager(IProvinciaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> CreateAsync(CreateProvinciaDto model)
        {
            var entity = _mapper.Map<Provincia>(model);

            var response = await _repository.CreateAsync(entity);
            var result = _mapper.Map<ResponseProvinciaDto>(response);
            if (!(result is null))
                return new Response("created", result);

            return new Response("Error", 500);



        }

        public async Task<Response> UpdateAsync(UpdateProvinciaDto model)
        {
            var entity = _mapper.Map<Provincia>(model);
            var updated = await _repository.UpdateAsync(entity);

            if (updated)
                return new Response("updated", null!);

            return new Response("Error", 500);
        }
        public async Task<Response> DeleteAsync(object Id)
        {
            var ProvinciaId = Convert.ToString(Id);

            var result = await _repository.DeleteAsync(ProvinciaId!);

            if (result)
                return new Response("deleted", 200);

            return new Response("Error", 500);
        }

        public async Task<Response> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var model= _mapper.Map<List<ResponseProvinciaDto>>(result);

            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (model.Any() || model.Count > 0)
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> GetByIdAsync(object id)
        {
            var result = await _repository.GetByIdAsync(id);
            var model= _mapper.Map<ResponseProvinciaDto>(result);

            if (model is null)
                return new Response("Não existe dados para mostrar",204);

            if (!string.IsNullOrEmpty(model?.Nome))
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> CreateProvincesAsync(IFormFile jsonPath)
        {
            var ProvinceCollection = new ExternalDataManager().GetJsonData(jsonPath);
            var entities = _mapper.Map<List<Provincia>>(ProvinceCollection.Result);
          
            var model= await _repository.CreateProvincesAsync(entities);

            if (model.Any())
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> GetByDescriptionAsync(string Description)
        {
            var result = await _repository.GetByDescriptionAsync(Description);
            var model = _mapper.Map<ResponseProvinciaDto>(result);


            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (!string.IsNullOrEmpty(model.Nome))
                return new Response(model);

            return new Response("Error", 500);
        }
    }
}
