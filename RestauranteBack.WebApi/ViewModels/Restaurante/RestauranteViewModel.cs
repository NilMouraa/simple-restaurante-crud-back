using RestauranteBack.WebApi.ViewModels.Prato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteBack.WebApi.ViewModels.Restaurante
{
    public class RestauranteViewModel
    {
        public int RestauranteId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<PratoViewModel> Pratos { get; set; }

    }
}
