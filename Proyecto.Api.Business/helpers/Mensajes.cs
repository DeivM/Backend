using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Api.Business.helpers
{
    public  class  Mensajes
    {
        public string Message { get; set; }
        public static string SuccessInsert()
        {
            return  "Datos registrados correctamente";
        }

        public static string SuccessUpdate()
        {
            return  "Datos actualizados correctamente";
        }

        public static string SuccessDelete()
        {
            return "Dato eliminado correctamente";
        }

        public static string ModelIvalid()
        {
            return "Datos del modelo inválido";
        }
        public static string NofountData()
        {
            return  "El dato no existe";
        }
        public static string ExistsData()
        {
            return "Ya existe información con los mismos datos";
        }

        public static string MedicoSinHorario()
        {
            return "El médico no tiene horario disponible para los datos ingresados actualmente, intentelo de nuevo en otro horario o fecha";
        }

        public static string EmailYaExiste()
        {
            return "EL correo electrónico ya existe";
        }

        public static string UserIncorrect()
        {
            return "Usuario o contraseña  incorrecta";
        }
        public static string UsuarioNoExiste()
        {
            return "Usuario no existe";
        }
        public static string ExisteVoto()
        {
            return "Usted ya no puedo volver a  realizar la votación";
        }
        public static string NoPuedeEliminarFichaInscripcion(string nombre)
        {
            return "Usted no puede elimnar la ficha inscripción de "+nombre+" porque ya tiene registrado votaciones";
        }
    }
}
