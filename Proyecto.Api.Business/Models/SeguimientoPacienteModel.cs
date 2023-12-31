﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Models
{
    public partial class SeguimientoPacienteModel
    {
        public long SepId { get; set; }
        public long? CasId { get; set; }
        public string SepObservacion { get; set; }
        public bool SepFinalizar { get; set; }
        public long? UsuId { get; set; }

        public long CitId { get; set; }

        public string CasNombre { get; set; }

        public string paciente { get; set; }

        public string medico { get; set; }

        public string  Finalizar { get; set; }
        public string Especialidad { get; set; }
        public string estadoSiNo { get; set; }

    }
}
