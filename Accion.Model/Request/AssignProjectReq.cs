using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Request
{
    public class AssignProjectReq : BaseRequest
    {
        public Guid EmpId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
