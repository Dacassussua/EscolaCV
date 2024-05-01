using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.PaisDto;
using EscolaCV.Manager.Interfaces.IPais;
using Microsoft.AspNetCore.Mvc;

namespace EscolaCV.WebApi.V1.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisManager _manager;
        public PaisController(IPaisManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Adicionar um novo País, para posterior associar as províncias, no corpo do json deve passar o código do pais e o Nome do pais
        /// </summary>
        /// <param name="model"></param>
        /// <returns>status:201</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]CreatePaisDto model)
        {
            var result = await _manager.CreateAsync(model);
            return Ok(result);
        }
        /// <summary>
        /// Alterar o Nome do país
        /// </summary>
        /// <param name="model"></param>
        /// <returns>status:201</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdatePaisDto model)
        {
            var result = await _manager.UpdateAsync(model);
            return Ok(result);
        }
        /// <summary>
        /// Remover um país pelo id
        /// </summary>
        /// <param name="PaisId"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery]string PaisId)
        {
            var result = await _manager.DeleteAsync(PaisId);
            return Ok(result);
        }
        /// <summary>
        /// Obter uma coleção de todos os país anteriormente registado
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
        /// Obter um país pelo Id
        /// </summary>
        /// <param name="PaisId"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string PaisId)
        {
            var result = await _manager.GetByIdAsync(PaisId);
            return Ok(result);
        }


    }
}
