using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WebLibrary.Entities;
using WebLibrary.Data;

namespace WebLibrary
{
    [ServiceContract(Namespace="http://mycompany.com/rates")]
    public interface IRateSys
    {
        [OperationContract]
        ICollection<Role> Roles();

        [OperationContract]
        ICollection<Rate> Rates();

        [OperationContract]
        ICollection<Employee> Employees();

        [OperationContract]
        bool AddEmployee(Employee emp);

        [OperationContract]
        bool AddRate(Rate rate);

        [OperationContract]
        bool AddRole(Role role);
    }
}
