using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Manager.Interfaces.IPais;
using EscolaCV.Manager.ValuesObjects;

namespace EscolaCV.Manager.Implementation
{
    public class PaisManager : IPaisManager
    {
        private readonly IPaisRepository _repository;
        private readonly IMapper _mapper;

        public PaisManager(IPaisRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> CreateAsync(Core.Share.DTOs.PaisDto.CreatePaisDto model)
        {
            var entity = _mapper.Map<Pais>(model);
            var response = await _repository.CreateAsync(entity);
            var result = _mapper.Map<Core.Share.DTOs.PaisDto.ResponsePaisDto>(response);
            if (!(result is null))
                return new Response("created", result);

            return new Response("Error", 500);

        }

        public async Task<Response> UpdateAsync(Core.Share.DTOs.PaisDto.UpdatePaisDto model)
        {
            var entity = _mapper.Map<Pais>(model);
            var result = await _repository.UpdateAsync(entity);

            if (result)
                return new Response("updated", null!);

            return new Response("Error", 500);
        }
        public async Task<Response> DeleteAsync(object Id)
        {
            var PaisId = Convert.ToString(Id);
            var result = await _repository.DeleteAsync(PaisId!);
            if (result)
                return new Response("deleted", 200);

            return new Response("Error", 500);
        }

        public async Task<Response> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var model= _mapper.Map<List<Core.Share.DTOs.PaisDto.ResponsePaisDto>>(result);

            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (model.Any() || model.Count>0)
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> GetByIdAsync(object id)
        {
            var result = await _repository.GetByIdAsync(id);
            var model = _mapper.Map<Core.Share.DTOs.PaisDto.ResponsePaisDto>(result);


            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (!string.IsNullOrEmpty(model.PaisId))
                return new Response(model);

            return new Response("Error", 500);
        }

  
        public async Task<Response> GetByDescriptionAsync(string Description)
        {
            var result = await _repository.GetByDescriptionAsync(Description);
            var model = _mapper.Map<Core.Share.DTOs.PaisDto.ResponsePaisDto>(result);


            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (!string.IsNullOrEmpty(model.PaisId))
                return new Response(model);

            return new Response("Error", 500);
        }
    }
}
