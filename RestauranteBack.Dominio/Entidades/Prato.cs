using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBack.Dominio.Entidades
{
    public class Prato
    {
        public int PratoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int RestauranteId { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}
