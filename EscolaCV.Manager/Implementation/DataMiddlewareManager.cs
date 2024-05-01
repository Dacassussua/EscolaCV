using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.ProvinciaDto;
using EscolaCV.Manager.Interfaces.IPais;
using EscolaCV.Manager.Interfaces.IProvincia;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProvinciaCV.Manager.Implementation;
using ProvinciaCV.Manager.Interfaces.IProvincia;
using System;
using System.Text.Json;
namespace EscolaCV.Manager.Implementation
{
    public class DataMiddlewareManager
    {
        private readonly IPaisManager _paisManager;
        private readonly IProvinciaManager _provinciaManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;

        public DataMiddlewareManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _paisManager = new PaisManager(_serviceProvider.GetRequiredService<IPaisRepository>(), _mapper);
            _provinciaManager = new ProvinciaManager(_serviceProvider.GetRequiredService<IProvinciaRepository>(), _mapper);
            Task.Run(() => Invoke());
        }

        public async Task Invoke()
        {
            await Task.FromResult(true);
            var respnse = new ExternalDataManager().GetJsonData(_serviceProvider.GetRequiredService<IFormFile>());
        }
    }



}
