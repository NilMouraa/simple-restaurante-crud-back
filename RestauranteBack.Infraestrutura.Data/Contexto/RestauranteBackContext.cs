using RestauranteBack.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestauranteBack.Infraestrutura.Data.EntityConfig;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestauranteBack.Infraestrutura.Data.Contexto
{
    public class RestauranteBackContext : DbContext
    {
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Prato> Prato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PratoConfig());
            modelBuilder.ApplyConfiguration(new RestauranteConfig());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("RestauranteDb"));
        }

    }
}
