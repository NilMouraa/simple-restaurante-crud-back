using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteBack.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteBack.Infraestrutura.Data.EntityConfig
{
    public class RestauranteConfig : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.HasKey(m => m.RestauranteId);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}

