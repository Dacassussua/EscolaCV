using EscolaCV.Core.Share.AppSettings;
using EscolaCV.Infra.Context;
using EscolaCV.WebApi.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<EscolaCVContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

StringConst.UserId = "CVA";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutomapperConfig();
builder.Services.AddDependenceInjectionConfiguration();
builder.Services.AddFluentValidationConfig();
builder.Services.AddSweggerConfig();


builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();


app.UseSweggerConfiguration();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();


app.Run();


