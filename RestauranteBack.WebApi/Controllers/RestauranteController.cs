using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestauranteBack.Dominio.Entidades;
using RestauranteBack.Servico.Servicos;
using RestauranteBack.WebApi.ViewModels.Restaurante;

namespace RestauranteBack.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : IController
    {
        readonly PratoService _pratoService = new PratoService();
        readonly RestauranteService _restauranteService = new RestauranteService();

        // GET: api/Restaurante
        [HttpGet]
        public string Get()
        {
            try
            {
                var restauranteEntity = _restauranteService.ObterTodos("").ToList();
                var restauranteViewModel = Mapper.Map<List<Restaurante>, List<RestauranteViewModel>>(restauranteEntity).ToList();

                return JsonConvert.SerializeObject(new { restaurantes = restauranteViewModel, success = true }, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { restaurantes = new { }, success = false });
            }
        }

        // GET: api/Restaurante/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var restauranteEntity = _restauranteService.ObterPorId(id);
                var restauranteViewModel = Mapper.Map<Restaurante, RestauranteViewModel>(restauranteEntity);

                return JsonConvert.SerializeObject(new { restaurante = restauranteViewModel, success = true }, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { restaurante = new { }, success = false });
            }
        }
        
        // POST: api/Restaurante
        [HttpPost]
        public void Post([FromBody] string value)
        {
            try
            {
                var RestauranteEntity = JsonConvert.DeserializeObject<Restaurante>(value);

                _restauranteService.Salvar(RestauranteEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // PUT: api/Restaurante/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            try
            {
                var RestauranteEntity = JsonConvert.DeserializeObject<Restaurante>(value);

                _restauranteService.Atualiza(RestauranteEntity);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _restauranteService.ExcluirPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
