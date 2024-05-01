using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace EscolaCV.WebApi.Configuration
{
    public static class SweggerConfig
    {
        public static void AddSweggerConfig(this IServiceCollection service)
        {
            service.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "EscolaCV",
                    Version = "V1",
                    Description = "EscolaCV",
           
                });

                x.AddFluentValidationRulesScoped();
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                x.IncludeXmlComments(xmlpath);
            });
        }

        public static void UseSweggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("./swagger/V1/swagger.json", "EscolaCV V1");
            });

        }
    }
}
