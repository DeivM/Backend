
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Contracts
{
   public interface IProyectoContext
    {

        DbSet<Usuario> Usuario { get; set; }

        DbSet<Empresa> Empresa { get; set; }
        DbSet<Menu> Menu { get; set; }
        DbSet<MenuPerfil> MenuPerfil { get; set; }
        DbSet<Perfil> Perfil { get; set; }
        DbSet<CatalogoSeguimiento> CatalogoSeguimiento { get; set; }
        DbSet<Cita> Cita { get; set; }
        DbSet<Especialidade> Especialidade { get; set; }
        DbSet<Horario> Horario { get; set; }
        DbSet<IndiceSeguimiento> IndiceSeguimiento { get; set; }
        DbSet<MedicosEspecialidade> MedicosEspecialidade { get; set; }
        DbSet<SeguimientoPaciente> SeguimientoPaciente { get; set; }

        Task<int> SaveChangesAsync(CancellationToken CancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);
        EntityEntry Entry(object entity);
        DatabaseFacade Database { get; }

    }
}
