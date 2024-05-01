using EscolaCV.Manager.Mapping.EscolaMapping;
using EscolaCV.Manager.Mapping.PaisMapping;
using EscolaCV.Manager.Mapping.ProvinciaMapping;

namespace EscolaCV.WebApi.Configuration
{
    public static class AutomapperConfig
    {
        public static void AddAutomapperConfig(this IServiceCollection services)
        {
            #region Mapping Escola
            services.AddAutoMapper(
                     typeof(CreateEscolaMappingProfile),
                     typeof(UpdateEscolaMappingProfile),
                     typeof(ResponseEscolaMappingProfile)
                     );
            #endregion
            #region Mapping Pais
            services.AddAutoMapper(
              typeof(CreatePaisMappingProfile),
              typeof(UpdatePaisMappingProfile),
              typeof(ResponsePaisMappingProfile)
              );
            #endregion  
            
            #region Mapping Provincia
            services.AddAutoMapper(
              typeof(CreateProvinciaMappingProfile),
              typeof(UpdateProvinciaMappingProfile),
              typeof(ResponseProvinciaMappingProfile)
              );
            #endregion    
            
            #region Mapping ExcelEscolaDTO to CreateEscolaDTO
            services.AddAutoMapper(
              typeof(ExcelEscolaMappingProfile)
              );
            #endregion

        }
    }
}
