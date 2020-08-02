using Accion.Business.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.CQRS
{
    public class DeleteEmployee : ICQRS<Guid, bool>
    {
        public async Task<bool> Execute(Guid request)
        {
            //DB/domain calls will be implemented here
            return await Task.FromResult(true);
        }
    }
}
