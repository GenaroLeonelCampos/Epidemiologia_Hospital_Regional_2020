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
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Epidemiologia.Class.Departamento> Departamento { get; set; }
        public DbSet<Epidemiologia.Class.Provincia> Provincia { get; set; }
        public DbSet<Epidemiologia.Class.Distrito> Distrito { get; set; }
        public DbSet<Epidemiologia.Class.Establecimiento> Establecimiento { get; set; }
        public DbSet<Epidemiologia.Class.Depmedico> Depmedico { get; set; }
        public DbSet<Epidemiologia.Class.Cartserv> Cartserv { get; set; }
        public DbSet<Epidemiologia.Class.UnidLab> UnidLab { get; set; }
        public DbSet<Epidemiologia.Class.GrupOcup> GrupOcup { get; set; }
        public DbSet<Epidemiologia.Class.Pertenencia> Pertenencia { get; set; }
        public DbSet<Epidemiologia.Class.Categoria> Categoria { get; set; }
        public DbSet<Epidemiologia.Class.Medicamento> Medicamento { get; set; }
        public DbSet<Epidemiologia.Class.Tipdoc> Tipdoc { get; set; }
        public DbSet<Epidemiologia.Class.Profesion> Profesion { get; set; }
        public DbSet<Epidemiologia.Class.PerSal> PerSal { get; set; }
        public DbSet<Epidemiologia.Class.AgregMedic> AgregMedic { get; set; }
        public DbSet<Epidemiologia.Class.Responsable> Responsable { get; set; }
        public DbSet<Epidemiologia.Class.SalidMedic> SalidMedic { get; set; }
    }
}
