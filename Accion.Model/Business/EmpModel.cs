using System;
using System.Collections.Generic;
using System.Text;

namespace Accion.Model.Business
{
    public class EmpModel
    {
        public Guid EmpId { get; set; }
        public string Initial { get; set; }
        public string EmpName { get; set; }
        public DateTime Dob { get; set; }
        public bool IsResigned { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }

    public enum EmployeeType
    {
        Contract,
        Permanent
    }
}
