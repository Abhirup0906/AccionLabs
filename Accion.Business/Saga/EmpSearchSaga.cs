using Accion.Business.Interface;
using Accion.Model.Business;
using Accion.Model.Request;
using Accion.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Saga
{
    public class EmpSearchSaga : ISaga<SearchEmpReq, SearchEmpResp>
    {
        ICQRS<SearchEmpReq, IEnumerable<EmpModel>> searchCqrs;
        public EmpSearchSaga(ICQRS<SearchEmpReq, IEnumerable<EmpModel>> searchCqrs)
        {
            this.searchCqrs = searchCqrs;
        }
        public async Task<SearchEmpResp> Send(SearchEmpReq request)
        {
            return new SearchEmpResp { Employees = await searchCqrs.Execute(request) };
        }
    }
}
