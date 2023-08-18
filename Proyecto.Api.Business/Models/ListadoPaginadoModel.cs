using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Proyecto.Api.Business.Models
{
    public class ListadoPaginadoModel<T>
    { 
        public int FiitidadElementos { get; set; }
        /// <summary> 
        /// Elementos devueltos para la página solicitada
        /// </summary> 
        public IEnumerable<T> Elementos { get; set; }

        public ListadoPaginadoModel()
        {
            FiitidadElementos = 0;
            Elementos = new List<T>();
        }
    }
}
