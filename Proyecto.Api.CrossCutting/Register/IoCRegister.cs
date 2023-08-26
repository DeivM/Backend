
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Api.Application.Contracts.Services;
using Proyecto.Api.Application.Services;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.DataAccess.Repositories;
namespace Proyecto.Api.CrossCutting.Register
{
  public static  class IoCRegister
    {
        public static IServiceCollection AddRegistration (this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            return services;
        }
        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<IPerfilService, PerfilService>();
            services.AddTransient<IMenuPerfilService, MenuPerfilService>();
            services.AddTransient<IMenuService, MenuService>();

            services.AddTransient<ICatalogoSeguimientoService, CatalogoSeguimientoService>();
            services.AddTransient<ICitaService, CitaService>();
            services.AddTransient<IEspecialidadeService, EspecialidadeService>();
            services.AddTransient<IHorarioService, HorarioService>();
            services.AddTransient<IIndiceSeguimientoService, IndiceSeguimientoService>();
            services.AddTransient<IMedicosEspecialidadeService, MedicosEspecialidadeService>();
            services.AddTransient<ISeguimientoPacienteService, SeguimientoPacienteService>();


            return services;
        }
        
        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            
            
            /*  services.AddTransient<IHobbyRepository, HobbyRepository>();
              services.AddTransient<IImagenFichaInscripcionRepository, ImagenFichaInscripcionRepository>();
              services.AddTransient<IMotivacioneRepository, MotivacioneRepository>();
              services.AddTransient<IResumenCuentasRepository, ResumenCuentasRepository>();
            */
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPerfilRepository, PerfilRepository>();
            services.AddTransient<IMenuPerfilRepository, MenuPerfilRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();

            services.AddTransient<ICatalogoSeguimientoRepository, CatalogoSeguimientoRepository>();
            services.AddTransient<ICitaRepository, CitaRepository>();
            services.AddTransient<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddTransient<IHorarioRepository, HorarioRepository>();
            services.AddTransient<IIndiceSeguimientoRepository, IndiceSeguimientoRepository>();
            services.AddTransient<IMedicosEspecialidadeRepository, MedicosEspecialidadeRepository>();
            services.AddTransient<ISeguimientoPacienteRepository, SeguimientoPacienteRepository>();


            return services;
        }
    }
}
