using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Manager.Interfaces.IEscola;
using EscolaCV.Manager.Interfaces.IProvincia;
using EscolaCV.Manager.ValuesObjects;

namespace EscolaCV.Manager.Implementation
{
    public class EscolaManager : IEscolaManager
    {
        private readonly IEscolaRepository _repository;
        private readonly IProvinciaRepository _provinciaRepository;
        private readonly IMapper _mapper;

        public EscolaManager(IEscolaRepository repository, IMapper mapper, IProvinciaRepository provinciaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _provinciaRepository = provinciaRepository;
        }

        public async Task<Response> CreateAsync(Core.Share.DTOs.EscolaDto.CreateEscolaDto model)
        {
            var entity = _mapper.Map<Escola>(model);
            var provincia = await _provinciaRepository.GetByDescriptionAsync(model.Provincia);
            entity.ProvinciaId = provincia.ProvinciaId;
            var response = await _repository.CreateAsync(entity);
            var result = _mapper.Map<Core.Share.DTOs.EscolaDto.ResponseEscolaDto>(response);
            if (!(result is null))
                return new Response("created", result);

            return new Response("Error", 500);
        }

        public async Task<Response> UpdateAsync(Core.Share.DTOs.EscolaDto.UpdateEscolaDto model)
        {
            var entity = _mapper.Map<Escola>(model);
            var updated = await _repository.UpdateAsync(entity);

            if (updated)
                return new Response("updated", null!);

            return new Response("Error", 500);
        }
        public async Task<Response> DeleteAsync(object Id)
        {
            var EscolaId = Convert.ToString(Id);
            var result = await _repository.DeleteAsync(EscolaId!);
            if (result)
                return new Response("deleted", 200);

            return new Response("Error", 500);
        }

        public async Task<Response> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var model = _mapper.Map<List<Core.Share.DTOs.EscolaDto.ResponseEscolaDto>>(result);

            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (model.Any() || model.Count > 0)
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> GetByIdAsync(object id)
        {
            var result = await _repository.GetByIdAsync(id);
            var model = _mapper.Map<Core.Share.DTOs.EscolaDto.ResponseEscolaDto>(result);

            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (!string.IsNullOrEmpty(model.Nome))
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> CreateEscolasAsync(IEnumerable<Core.Share.DTOs.EscolaDto.ExcelEscolaDto> collection)
        {
            var escolas = new List<Escola>();
            foreach (var item in collection)
            {
                var exist = await _provinciaRepository.GetByDescriptionAsync(item.Provincia);
                if (exist != null)
                {
                    var escolaDto = _mapper.Map<Core.Share.DTOs.EscolaDto.CreateEscolaDto>(item);
                    var escola = _mapper.Map<Escola>(escolaDto);
                    escola.ProvinciaId = exist.ProvinciaId;


                    escolas.Add(escola);
                }
            }
            var result = await _repository.CreateEscolasAsync(escolas);
            var model = _mapper.Map<List<Core.Share.DTOs.EscolaDto.ResponseEscolaDto>>(result);

            if (model.Any() || model.Count > 0)
                return new Response(model);

            return new Response("Error", 500);
        }

        public async Task<Response> GetByDescriptionAsync(string Description)
        {
            var result = await _repository.GetByDescriptionAsync(Description);
            var model = _mapper.Map<Core.Share.DTOs.EscolaDto.ResponseEscolaDto>(result);

            if (model is null)
                return new Response("Não existe dados para mostrar", 204);

            if (!string.IsNullOrEmpty(model.Nome))
                return new Response(model);

            return new Response("Error", 500);
        }
    }
}
