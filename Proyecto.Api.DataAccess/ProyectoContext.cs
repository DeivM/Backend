
using Microsoft.EntityFrameworkCore;
using Proyecto.Api.DataAccess.Contracts;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.DataAccess.EntityConfig;

namespace Proyecto.Api.DataAccess
{
    public  class ProyectoContext : DbContext, IProyectoContext
    {
        public ProyectoContext(DbContextOptions options) : base(options)
        {
        }

        
        public virtual DbSet<Usuario> Usuario { get; set; }
       
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuPerfil> MenuPerfil { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }

        public virtual DbSet<CatalogoSeguimiento> CatalogoSeguimiento { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<IndiceSeguimiento> IndiceSeguimiento { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<MedicosEspecialidade> MedicosEspecialidade { get; set; }
        public virtual DbSet<SeguimientoPaciente> SeguimientoPaciente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            UsuarioEntityConfig.SetEntityBuilder(modelBuilder.Entity<Usuario>());

            EmpresaEntityConfig.SetEntityBuilder(modelBuilder.Entity<Empresa>());
            MenuEntityConfig.SetEntityBuilder(modelBuilder.Entity<Menu>());
            MenuPerfilEntityConfig.SetEntityBuilder(modelBuilder.Entity<MenuPerfil>());
            PerfilEntityConfig.SetEntityBuilder(modelBuilder.Entity<Perfil>());


            CatalogoSeguimientoEntityConfig.SetEntityBuilder(modelBuilder.Entity<CatalogoSeguimiento>());
            CitaEntityConfig.SetEntityBuilder(modelBuilder.Entity<Cita>());
            EspecialidadeEntityConfig.SetEntityBuilder(modelBuilder.Entity<Especialidade>());
            HorarioEntityConfig.SetEntityBuilder(modelBuilder.Entity<Horario>());
            IndiceSeguimientoEntityConfig.SetEntityBuilder(modelBuilder.Entity<IndiceSeguimiento>());
            MedicoEntityConfig.SetEntityBuilder(modelBuilder.Entity<Medico>());
            MedicosEspecialidadeEntityConfig.SetEntityBuilder(modelBuilder.Entity<MedicosEspecialidade>());
            SeguimientoPacienteEntityConfig.SetEntityBuilder(modelBuilder.Entity<SeguimientoPaciente>());



            base.OnModelCreating(modelBuilder);
        }
    }
}
