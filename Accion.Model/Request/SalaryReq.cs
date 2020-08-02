using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Request
{
    public class SalaryReq: BaseRequest
    {
        public Guid EmpId { get; set; }
    }
}
