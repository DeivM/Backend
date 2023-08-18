﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class CitaRequest
    {
        public long CitId { get; set; }
        public long? MesId { get; set; }
        public DateTime? CitFechaAtencion { get; set; }
        public TimeSpan? CitInicioAtencion { get; set; }
        public TimeSpan? CitFinAtencion { get; set; }
        public string CitEstadoPaciente { get; set; }
        public string CitObservaciones { get; set; }
        public short? CitEstado { get; set; }
        public long? UsuId { get; set; }

    }
}
