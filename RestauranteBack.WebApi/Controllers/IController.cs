using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestauranteBack.WebApi.ViewModels.Prato;
using RestauranteBack.Dominio.Entidades;
using RestauranteBack.WebApi.ViewModels.Restaurante;

namespace RestauranteBack.WebApi.Controllers
{
    public abstract class IController : Controller
    {
        public MapperConfiguration AutomapperConfig { get; set; }
        public IMapper Mapper { get; set; }

        protected IController()
        {
            AutomapperConfig = new MapperConfiguration(cfg =>
            {
                #region entidade -> viewModel

                cfg.CreateMap<Restaurante, RestauranteViewModel>();
                cfg.CreateMap<Prato, PratoViewModel>();

                #endregion

                #region viewModel -> entidade

                cfg.CreateMap<RestauranteViewModel, Restaurante>();
                cfg.CreateMap<PratoViewModel, Prato>();
                
                #endregion
            });

            Mapper = AutomapperConfig.CreateMapper();
        }
    }
}