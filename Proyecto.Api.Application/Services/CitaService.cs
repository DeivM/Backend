
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Api.Application.Contracts.Services;
using Proyecto.Api.Business.helpers;
using Proyecto.Api.Business.Models;
using Proyecto.Api.DataAccess.Contracts.Repositories;
using Proyecto.Api.Business.Request;
using Proyecto.Api.DataAccess.Contracts.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace Proyecto.Api.Application.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _CitaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _medicoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IEspecialidadeService _especialidadService;
        private readonly ICatalogoSeguimientoService _seguimientoService;
        

        public CitaService(ICitaRepository CitaRepository,
            IMapper mapper,
            IUsuarioService medicoService,
            IUsuarioService usuarioService,
            IEspecialidadeService especialidadService,
            ICatalogoSeguimientoService seguimientoService
            )
        {
            _CitaRepository = CitaRepository;
            _mapper = mapper;
            _medicoService = medicoService;
            _usuarioService = usuarioService;
            _seguimientoService = seguimientoService;
            _especialidadService = especialidadService;
        }
        public async Task<bool> Exist(string nombre)
        {
            return await _CitaRepository.Exist(nombre);
        }
        public async Task<bool> Exist(long id)
        {
            return await _CitaRepository.Exist(id);
        }

        //servicio que obtiene un solo dato por la clave principal id
        public async Task<CitaModel> Get(long id)
        {
            return await _CitaRepository.Get(id);
        }

        //Retorna todos los datos que tiene la tabla, regresa siempre los 10 primeros, ordenados por id principal
        //quantity Fiitidad de datos que desea consultar
        //page numero de paginas
        //orderBy ordenaod por desc o asc
        //orderType el campo de ordenamiento 
        //searchText texto para realizar la busqueda
        public async Task<ListadoPaginadoModel<CitaModel>> GetAll(int quantity, int page, string orderBy, string orderType, string searchText, int PerId, int UsuId)
        {
            return await _CitaRepository.GetAll(quantity, page, orderBy, orderType, searchText, PerId, UsuId);
        }

       

        //obtiene la informacion para mostrar en el formulario de registro 
        public async Task<CitaData> GetData(long id)
        {
            var data = new CitaData();
            if (id > 0)
            {
                data.Data = await Get(id);
                var medicos = await _medicoService.GetList(data.Data.EspId.Value);

            }
            //data.Medicos =await _medicoService.GetList();
            data.Pacientes = await _usuarioService.GetList();
            data.MedicosEspecialidad = await _especialidadService.GetList();
            data.Citas = await _CitaRepository.GetList();
            return data;
        }

        //envia la informacion al repositorio para ingresar y regresa un long como exito
        public async Task<long> Add(CitaRequest data)
        {
            if (await Exist(data.CitEstadoPaciente)) throw new Exception(Mensajes.ExistsData());

            if (await _CitaRepository.ValidarCitasHorario(data.MesId.Value, data.CitFechaAtencion.Value, data.CitInicioAtencion.Value, data.CitFinAtencion.Value)) throw new Exception(Mensajes.MedicoSinHorario());
            
            var id = await _CitaRepository.Add(_mapper.Map<Cita>(data));

            enviarMensajeWhatsApp(data.UsuId.Value, id);

            return id;
        }

        //envia la informacion al repositorio para actualizar y regresa un long como exito
        public async Task<long> Update(CitaRequest data)
        {
            return await _CitaRepository.Update(_mapper.Map<Cita>(data));
        }

        //envia la informacion al repositorio para eliminar y regresa un long como exito
        public async Task<long> Delete(List<long> ids)
        {
            return await _CitaRepository.Delete(ids);
        }

        public async Task<List<CitaModel>> GetAllById(int id)
        {
            
            return await _CitaRepository.GetAllById(id);

        }

       private async void enviarMensajeWhatsApp(long id, long citId)
        {
            try
            {

           
            var usuario = await _usuarioService.Get(id);
            var cita = await _CitaRepository.Get(citId);
            string cuerpo=string.Empty;
            cuerpo = "hola "+usuario.UsuNombres +" "+usuario.UsuApellidos
                +   " Reciba un cordial saludo de quienes conformamos SALUDSPC"
                +"\n\n"
                +"Le informamos que usted tiene uan cita con la siguiente información"
                  + "\n\n"
                  +"Especialidad "+cita.EspNombre +"\n\n"
                  +"Médico "+cita.MedNombres +"\n\n"
                  +"Fecha "+cita.CitFechaAtencion.Value.ToShortDateString()+"\n\n"
                  +"Hora "+cita.CitInicioAtencion.Value.ToString() +"\n\n"
                ;

            string fromEmail = "david.saludspc@gmial.com";
            string fromPassWord = "tqqbliwqdjtgjhow";
            MailMessage message = new MailMessage();
            message.From=new MailAddress(fromEmail);
            message.Subject = "Cita Asignada";

            message.To.Add(new MailAddress(usuario.UsuEmail));
            message.Body = cuerpo;
            message.IsBodyHtml = true;
            var smtClient = new SmtpClient("smtp.gmail.com")
            {
                Port=587,
                Credentials=new NetworkCredential(fromEmail, fromPassWord),
                EnableSsl=true
            };
            smtClient.Send(message);
            }
            catch (Exception)
            {

               
            }

        }


    }
}
