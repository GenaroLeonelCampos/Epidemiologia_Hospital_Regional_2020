using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Epidemiologia.Areas.Users.Models;
using Epidemiologia.Areas.Tipdoc.Models;
using Epidemiologia.Class;
using Epidemiologia.ListaModelos;

namespace Epidemiologia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        static DbContextOptions<ApplicationDbContext> _options;
        public ApplicationDbContext() : base(_options)
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
        }
        public DbSet<TUsers> TUsers { get; set; }       
        
        public DbSet<Epidemiologia.Class.Empleados> Empleados { get; set; }
        public DbSet<Epidemiologia.Class.TiposSexo> TiposSexo { get; set; }
        public DbSet<Epidemiologia.Class.Paises> Paises { get; set; }
        public DbSet<Epidemiologia.Class.Farmsaldo> Farmsaldo { get; set; }
        public DbSet<Epidemiologia.Class.farmAlmacen> farmAlmacen { get; set; }
        public DbSet<Epidemiologia.Class.FactCatalogoBienesInsumos> FactCatalogoBienesInsumos { get; set; }
        public DbSet<Epidemiologia.Class.farmTipoSalidaBienInsumo> farmTipoSalidaBienInsumo { get; set; }
    }
}
