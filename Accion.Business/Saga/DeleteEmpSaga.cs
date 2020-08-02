using Accion.Business.Interface;
using Accion.Model.Request;
using Accion.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Saga
{
    public class DeleteEmpSaga : ISaga<DeleteEmpReq, EmpCrudResp>
    {
        ICQRS<Guid, bool> deleteCqrs;
        public DeleteEmpSaga(ICQRS<Guid, bool> deleteCqrs)
        {
            this.deleteCqrs = deleteCqrs;
        }

        public async Task<EmpCrudResp> Send(DeleteEmpReq request)
        {
            //other opration like email, push message in event hub or other required operations
            return new EmpCrudResp { IsSuccess = await deleteCqrs.Execute(request.EmpId) };
        }
    }
}
