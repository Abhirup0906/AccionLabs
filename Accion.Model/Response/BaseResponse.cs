using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Response
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}
