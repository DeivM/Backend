﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Api.Business.Request
{
    public partial class MedicoRequest
    {
      
        public long UsuId { get; set; }
        public string MedNombres { get; set; }
        public string MedApellidos { get; set; }
        public string MedCedula { get; set; }
        public string MedDireccion { get; set; }
        public string MedCorreo { get; set; }
        public string MedTelefono { get; set; }
        public string MedSexo { get; set; }
        public string MedNumCsp { get; set; }
        public short? MedEstado { get; set; }
        public long? EmpId { get; set; }

        
    }
}
