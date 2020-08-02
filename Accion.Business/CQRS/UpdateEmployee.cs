using Accion.Business.Interface;
using Accion.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.CQRS
{
    public class UpdateEmployee : ICQRS<EmpModel, bool>
    {
        public async Task<bool> Execute(EmpModel request)
        {
            //DB/domain calls will be implemented here
            return await Task.FromResult(true);
        }
    }
}
