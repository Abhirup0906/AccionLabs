using Accion.Model.Request;
using Accion.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Interface
{
    public interface ISaga<T,U> where T: BaseRequest
                                where U: BaseResponse
    {
        Task<U> Send(T request);
    }
}
