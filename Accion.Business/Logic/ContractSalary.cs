using Accion.Business.Interface;
using Accion.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Logic
{
    public class ContractSalary : ISalaryProcess
    {
        public async Task<bool> ProcessSalary(EmpModel emp)
        {
            //contract salary generation logic
            return await Task.FromResult(true);
        }
    }
}
