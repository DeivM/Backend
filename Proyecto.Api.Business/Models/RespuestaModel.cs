
using System.Collections.Generic;
using System.Net;
namespace Proyecto.Api.Business.Models
{
    public class RespuestaModel<T>
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }

        public RespuestaModel()
        {
            Id = 0;
            Message = string.Empty;
            Code = HttpStatusCode.OK;
            Data = default(T);
            Success = true;
        }
    }
}
