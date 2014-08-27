using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerApplication.Data
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int RateID { get; set; }
    }

    public class Rate
    {
        public int RateID { get; set; }
        public string RateDescription { get; set; }
        public decimal Value { get; set; }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeNumber { get; set; }
        public int RoleID { get; set; }
    }
}
