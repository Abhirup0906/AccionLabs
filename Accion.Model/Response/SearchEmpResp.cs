using Accion.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Response
{
    public class SearchEmpResp: BaseResponse
    {
        public IEnumerable<EmpModel> Employees { get; set; }
    }
}
