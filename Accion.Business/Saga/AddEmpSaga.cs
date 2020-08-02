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
    public class AddEmpSaga : ISaga<AddEmpRequest, EmpCrudResp>
    {
        ICQRS<EmpModel, bool> updateCqrs;
        public AddEmpSaga(ICQRS<EmpModel, bool> updateCqrs)
        {
            this.updateCqrs = updateCqrs;
        }
        public async Task<EmpCrudResp> Send(AddEmpRequest request)
        {
            //other opration like email, push message in event hub or other required operations
            return new EmpCrudResp { IsSuccess = await updateCqrs.Execute(request.Employee) };
        }
    }
}
