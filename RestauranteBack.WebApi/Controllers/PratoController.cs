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
using RestauranteBack.WebApi.ViewModels.Prato;

namespace RestauranteBack.WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class PratoController : IController
    {
        readonly PratoService _pratoService = new PratoService();
        readonly PratoService _restauranteService = new PratoService();

        // GET: api/Prato
        [HttpGet]
        public string Get()
        {
            try
            {
                var pratosEntity = _restauranteService.ObterTodos("Restaurante").ToList();
                var pratosViewModel = Mapper.Map<List<Prato>, List<PratoViewModel>>(pratosEntity).ToList();

                return JsonConvert.SerializeObject(new { pratos = pratosViewModel, success = true }, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new { pratos = new { }, success = false });
            }
        }

        // GET: api/Prato/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var pratoEntity = _pratoService.ObterPorId(id);
                var pratoViewModel = Mapper.Map<Prato, PratoViewModel>(pratoEntity);

                return JsonConvert.SerializeObject(new { prato = pratoViewModel, success = true }, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { prato = new { }, success = false });
            }
        }

        // POST: api/Prato
        [HttpPost]
        public void Post([FromBody]string value)
        {
            try
            {
                var PratoEntity = JsonConvert.DeserializeObject<Prato>(value);
                _pratoService.Salvar(PratoEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
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
            try
            {
                _pratoService.ExcluirPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
