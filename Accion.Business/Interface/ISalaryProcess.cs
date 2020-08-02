using Accion.Model.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Interface
{
    public interface ISalaryProcess
    {
        Task<bool> ProcessSalary(EmpModel emp);
    }
}
