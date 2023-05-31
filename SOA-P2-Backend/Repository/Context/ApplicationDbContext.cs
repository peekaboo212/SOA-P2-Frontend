using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Activo> Activos { get; set; }
        public virtual DbSet<Activo_Empleado> Activo_Empleado { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionStrings = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            optionsBuilder.UseSqlServer(connectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
