using Accion.Business.Interface;
using Accion.Model.Business;
using Accion.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.CQRS
{
    public class SearchEmployee : ICQRS<SearchEmpReq, IEnumerable<EmpModel>>
    {
        public async Task<IEnumerable<EmpModel>> Execute(SearchEmpReq request)
        {
            return await Task.FromResult(new List<EmpModel>() { new EmpModel { EmployeeType=EmployeeType.Contract },
                                                                new EmpModel { EmployeeType= EmployeeType.Permanent } });
        }
    }
}
