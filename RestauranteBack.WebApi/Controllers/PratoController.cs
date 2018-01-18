using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestauranteBack.Dominio.Entidades;
using RestauranteBack.Servico.Servicos;
using RestauranteBack.WebApi.ViewModels.Prato;

namespace RestauranteBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PratoController : IController
    {
        readonly PratoService _pratoService = new PratoService();
        readonly PratoService _restauranteService = new PratoService();

        // GET: api/Prato
        [HttpGet]
        public string Get()
        {
           var pratosEntity = _restauranteService.ObterTodos("Restaurante").ToList();

            var pratosViewModel = Mapper.Map<List<Prato>, List<PratoViewModel>>(pratosEntity);

            return JsonConvert.SerializeObject(pratosViewModel, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            
        }

        // GET: api/Prato/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Prato
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Prato/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
