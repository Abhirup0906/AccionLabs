using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accion.Business.Interface;
using Accion.Model.Request;
using Accion.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accion.EmployeeMgmt.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ISaga<AddEmpRequest, EmpCrudResp> addEmp;
        ISaga<DeleteEmpReq, EmpCrudResp> deleteEmp;
        ISaga<SearchEmpReq, SearchEmpResp> searchEmp;
        ISaga<SalaryReq, EmpSalaryResp> empSalary;
        ISaga<UpdateEmpReq, EmpCrudResp> updateEmp;

        public EmployeeController(ISaga<AddEmpRequest, EmpCrudResp> addEmp,
                                  ISaga<DeleteEmpReq, EmpCrudResp> deleteEmp,
                                  ISaga<SearchEmpReq, SearchEmpResp> searchEmp,
                                  ISaga<SalaryReq, EmpSalaryResp> empSalary,
                                  ISaga<UpdateEmpReq, EmpCrudResp> updateEmp)
        {
            this.addEmp = addEmp;
            this.deleteEmp = deleteEmp;
            this.searchEmp = searchEmp;
            this.empSalary = empSalary;
            this.updateEmp = updateEmp;
        }

        [HttpPost]
        public async Task<ActionResult<EmpCrudResp>> AddEmployee(AddEmpRequest request)
        {
            return await addEmp.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<EmpCrudResp>> UpdateEmployee(UpdateEmpReq request)
        {
            return await updateEmp.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<SearchEmpResp>> SearchEmployee(SearchEmpReq request)
        {
            return await searchEmp.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<EmpCrudResp>> DeleteEmployee(DeleteEmpReq request)
        {
            return await deleteEmp.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<EmpSalaryResp>> PaySalary(SalaryReq request)
        {
            return await empSalary.Send(request);
        }
    }
}
