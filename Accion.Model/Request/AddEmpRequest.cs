using Accion.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Request
{
    public class AddEmpRequest : BaseRequest
    {
        public EmpModel Employee { get; set; }
    }
}
