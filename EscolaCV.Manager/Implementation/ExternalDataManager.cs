using EscolaCV.Core.Share.DTOs.EscolaDto;
using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Text.Json;

namespace EscolaCV.Manager.Implementation
{
    public class ExternalDataManager
    {
        public ExternalDataManager()
        {

        }

        public async Task<IEnumerable<CreateProvinciaDto>> GetJsonData(IFormFile jsonPath)
        {
            var collection = new List<CreateProvinciaDto>();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {

                string jsonData = string.Empty;
                using (var reader = new StreamReader(jsonPath.OpenReadStream()))
                {
                    jsonData = await reader.ReadToEndAsync();
          
                    var pais = JsonSerializer.Deserialize<JsonData>(jsonData, options);
                    if (!(pais is null))
                        collection = pais.Angola.Provincias;
                }

            }
            catch
            {
                throw new Exception("Não foi possível ler o ficheiro json");
            }


            return collection;
        }


        public async Task<IEnumerable<ExcelEscolaDto>> GetCSVData(IFormFile file)
        {

            var products = new List<ExcelEscolaDto>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                using (var package = new ExcelPackage(stream))
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var worksheet = package.Workbook.Worksheets[0];

                        for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                        {
                            var product = new ExcelEscolaDto
                            {
                                Nome = worksheet.Cells[row, 1].Value?.ToString()!,
                                Email = worksheet.Cells[row, 2].Value?.ToString()!,
                                NumSalas = int.Parse(worksheet.Cells[row, 3].Value?.ToString()!)!,
                                Provincia = worksheet.Cells[row, 4].Value?.ToString()!
                            };

                            products.Add(product);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro ao ler o ficheiro\n{ex}");
                    }
                }
            }

            return products;
        }


    }



    public class Angola
    {
        public List<CreateProvinciaDto> Provincias { get; set; } = new();
    }
    public class JsonData
    {
        public Angola Angola { get; set; } = new();
    }

}
