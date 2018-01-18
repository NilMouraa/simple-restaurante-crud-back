using RestauranteBack.WebApi.ViewModels.Restaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteBack.WebApi.ViewModels.Prato
{
    public class PratoViewModel
    {
        public int PratoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public RestauranteViewModel Restaurante { get; set; }
    }
}
