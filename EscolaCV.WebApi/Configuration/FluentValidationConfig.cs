using EscolaCV.Manager.Validator.EscolaValidator;
using EscolaCV.Manager.Validator.PaisValidator;
using EscolaCV.Manager.Validator.ProvinciaValidator;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;

namespace EscolaCV.WebApi.Configuration
{
    public static class FluentValidationConfig
    {

        public static void AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddControllers()
         .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)

         .AddFluentValidation(x =>
         {
             x.RegisterValidatorsFromAssemblyContaining<CreateEscolaValidator>();
             x.RegisterValidatorsFromAssemblyContaining<UpdateEscolaValidator>();

             x.RegisterValidatorsFromAssemblyContaining<CreatePaisValidator>();
             x.RegisterValidatorsFromAssemblyContaining<UpdatePaisValidator>();

             x.RegisterValidatorsFromAssemblyContaining<CreateProvinciaValidator>();
             x.RegisterValidatorsFromAssemblyContaining<UpdateProvinciaValidator>();
         });
        }
    }
}
