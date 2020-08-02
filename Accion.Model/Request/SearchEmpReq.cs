using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Request
{
    public class SearchEmpReq: BaseRequest
    {
        public Guid EmpId { get; set; }
        public string EmpName { get; set; }        
        public bool IsResigned { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
