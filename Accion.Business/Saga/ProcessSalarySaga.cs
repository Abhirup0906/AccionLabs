using Accion.Business.Interface;
using Accion.Model.Business;
using Accion.Model.Request;
using Accion.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accion.Business.Saga
{
    public class ProcessSalarySaga : ISaga<SalaryReq, EmpSalaryResp>
    {
        Func<EmployeeType, ISalaryProcess> salaryProcess;
        ICQRS<SearchEmpReq, IEnumerable<EmpModel>> searchCqrs;
        public ProcessSalarySaga(ICQRS<SearchEmpReq, IEnumerable<EmpModel>> searchCqrs,
                                Func<EmployeeType, ISalaryProcess> salaryProcess)
        {
            this.searchCqrs = searchCqrs;
            this.salaryProcess = salaryProcess;
        }
        public async Task<EmpSalaryResp> Send(SalaryReq request)
        {
            var empDetails = (await searchCqrs.Execute(new SearchEmpReq() { EmpId = request.EmpId })).First();
            return new EmpSalaryResp { IsSuccess = await salaryProcess(empDetails.EmployeeType).ProcessSalary(empDetails) };
        }
    }
}
