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
    public class PratoConfig : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.HasKey(m => m.PratoId);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(m => m.Restaurante)
                .WithMany(x => x.Pratos)
                .HasForeignKey(m => m.RestauranteId);
        }    
    }
}
