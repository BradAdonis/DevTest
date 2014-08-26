using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebLibrary.Entities
{
    [DataContract]
    public class Role
    {
        public Role()
        {
            Employees = new List<Employee>();
        }
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public int RateID { get; set; }
        [DataMember]
        public virtual Rate Rate { get; set; }
        [DataMember]
        public virtual ICollection<Employee> Employees { get; set; }
    }

    [DataContract]
    public class Rate
    {
        public Rate()
        {
            Roles = new List<Role>();
        }

        [DataMember]
        public int RateID { get; set; }
        [DataMember]
        public decimal Value { get; set; }
        [DataMember]
        public virtual ICollection<Role> Roles { get; set; }
    }

    [DataContract]
    public class Employee
    {
        public Employee() { }

        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string EmployeeSurname { get; set; }
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public virtual Role Role { get; set; }
    }
}
