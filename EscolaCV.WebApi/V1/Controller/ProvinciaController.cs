using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using EscolaCV.Manager.Implementation;
using EscolaCV.Manager.Interfaces.IProvincia;
using Microsoft.AspNetCore.Mvc;
using ProvinciaCV.Manager.Interfaces.IProvincia;

namespace EscolaCV.WebApi.V1.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaManager _manager;
        public ProvinciaController(IProvinciaManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Adcionar/Cadastrar uma nova Provincia
        /// </summary>
        /// <param name="model"> </param>
        /// <returns>status:201</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateProvinciaDto model)
        {
            var result = await _manager.CreateAsync(model);
            return Ok(result);
        }


        /// <summary>
        /// Editar o nome da província
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateProvinciaDto model)
        {
            var result = await _manager.UpdateAsync(model);
            return Ok(result);
        }
        /// <summary>
        /// Remover uma província pelo Id
        /// </summary>
        /// <param name="ProvinciaId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] string ProvinciaId)
        {
            var result = await _manager.DeleteAsync(ProvinciaId);
            return Ok(result);
        }
        /// <summary>
        /// Obter uma coleção de província
        /// </summary>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _manager.GetAllAsync();
            return Ok(result);
        }
        /// <summary>
        /// Obter uma prvíncia pelo Id
        /// </summary>
        /// <param name="ProvinciaId"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string ProvinciaId)
        {
            var result = await _manager.GetByIdAsync(ProvinciaId);
            return Ok(result);
        }


        /// <summary>
        /// Adicionar províncias por meio de um ficheiro Json. o ficheiro deve obedecer ao modelo previamente disponibilizado
        /// </summary>
        /// <param name="jsonFile"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("UploadJson")]
        public async Task<IActionResult> UploadExcelFile(IFormFile jsonFile)
        {
            await Task.FromResult(true);
            try
            {
                if (jsonFile == null || jsonFile.Length == 0)
                {
                    return BadRequest("Adicione um ficheiro json com os dados da província");
                }

                // Verifica se o arquivo é um arquivo Excel
                if (Path.GetExtension(jsonFile.FileName).ToLower() != ".json")
                {
                    return BadRequest("Por favor carregue um ficheiro json válido.");
                }
                var result = await _manager.CreateProvincesAsync(jsonFile);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
