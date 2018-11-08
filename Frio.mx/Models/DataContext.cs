namespace Frio.mx.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Web;

    public class DataContext : DbContext
    {
        public DataContext() : base ("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Torneo> Torneos { get; set; }

        public DbSet<Temporada> Temporadas { get; set; }

        public DbSet<Equipo> Equipos { get; set; }
    }
}