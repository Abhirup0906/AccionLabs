using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Interface
{
    public interface ICQRS<T,U>
    {
        Task<U> Execute(T request);
    }
}
