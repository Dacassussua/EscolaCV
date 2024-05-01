using EscolaCV.Core.Share.DTOs.EscolaDto;
using EscolaCV.Manager.Implementation;
using EscolaCV.Manager.Interfaces.IEscola;
using Microsoft.AspNetCore.Mvc;

namespace EscolaCV.WebApi.V1.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaManager _manager;
        public EscolaController(IEscolaManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Adiicona uma nova escola, passando um json com o Nome,Email, Número de salas e a província
        /// </summary>
        /// <param name="model"></param>
        /// <returns>status:201</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEscolaDto model)
        {
            var result = await _manager.CreateAsync(model);
            return Ok(result);
        }
        /// <summary>
        /// Actualizar os dados de uma escola
        /// </summary>
        /// <param name="model"></param>
        /// <returns>status: 200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEscolaDto model)
        {
            var result = await _manager.UpdateAsync(model);
            return Ok(result);
        }
        /// <summary>
        /// Apagar uma escola
        /// </summary>
        /// <param name="EscolaId"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] string EscolaId)
        {
            var result = await _manager.DeleteAsync(EscolaId);
            return Ok(result);
        }
        /// <summary>
        /// obter uma coleção de escolas
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
        /// obter uma escola pelo Id
        /// </summary>
        /// <param name="EscolaId"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string EscolaId)
        {
            var result = await _manager.GetByIdAsync(EscolaId);
                return Ok(result);

        }


        /// <summary>
        /// Carregar dados de uma escola por meio de um ficheiro excel
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns>status:200</returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("UploadExcel")]
        public async Task<IActionResult> UploadExcelFile(IFormFile excelFile)
        {
            try
            {
                if (excelFile == null || excelFile.Length == 0)
                {
                    return BadRequest("Adicione um ficheiro excel com os dados da Escola");
                }

                // Verifica se o arquivo é um arquivo Excel
                if (Path.GetExtension(excelFile.FileName).ToLower() != ".xls" && Path.GetExtension(excelFile.FileName).ToLower() != ".xlsx")
                {
                    return BadRequest("Por favor carregue um ficheiro excel válido.");
                }

                var escolasExcel = new ExternalDataManager().GetCSVData(excelFile).Result;
                var result = await _manager.CreateEscolasAsync(escolasExcel);

                    return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
