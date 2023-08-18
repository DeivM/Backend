using AutoMapper;
using System.Collections.Generic;
using Proyecto.Api.Business.Request;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.Mappers
{
  public  class AutoMappingProfile: Profile
    {
        public AutoMappingProfile()
        {
      
            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<PerfilRequest, Perfil>();
            CreateMap<PerfilRequest, Perfil>();
            CreateMap<MenuPerfilRequest, MenuPerfil>();
            CreateMap<MenuRequest, Menu>();

            CreateMap<CatalogoSeguimientoRequest, CatalogoSeguimiento>();
            CreateMap<CitaRequest, Cita>();
            CreateMap<EspecialidadeRequest, Especialidade>();
            CreateMap<HorarioRequest, Horario>();
            CreateMap<IndiceSeguimientoRequest, IndiceSeguimiento>();
            CreateMap<MedicoRequest, Medico>();
            CreateMap<MedicosEspecialidadeRequest, MedicosEspecialidade>();
            CreateMap<SeguimientoPacienteRequest, SeguimientoPaciente>();

        }
    }
}
