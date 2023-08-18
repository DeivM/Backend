using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.common.extension
{
    public static class HttpExtensions
    {
        public static int ObtenerImpresaIdHeader(this ControllerBase httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue("x-empresa-id", out StringValues headerValues))
                return Convert.ToInt32(headerValues.FirstOrDefault());

            return 0;
        }
    }
}
