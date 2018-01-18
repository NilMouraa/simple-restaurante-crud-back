using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBack.Dominio.Entidades
{
    public class Restaurante
    {
        public int RestauranteId { get; set; }
        public string Nome{ get; set; }
        public virtual ICollection<Prato> Pratos { get; set; }
    }
}
