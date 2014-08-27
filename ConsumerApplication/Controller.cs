using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerApplication
{
    public static class Controller
    {
        public static ICollection<Data.Employee> getEmployees()
        {
            ICollection<Data.Employee> lstEmployees = new List<Data.Employee>();

            using (refRatesWeb.RateSysClient call = new refRatesWeb.RateSysClient())
            {
                ICollection<refRatesWeb.Employee> Employees = call.Employees();

                if (Employees.Count > 0)
                {
                    foreach (refRatesWeb.Employee e in Employees)
                    {
                        Data.Employee employee = new Data.Employee 
                        { 
                            EmployeeID = e.EmployeeID,
                            EmployeeName = e.EmployeeName,
                            EmployeeNumber = e.EmployeeNumber,
                            EmployeeSurname = e.EmployeeSurname,
                            RoleID = e.RoleID,
                        };

                        lstEmployees.Add(employee);
                    }
                }

                return lstEmployees;
            }
        }

        public static ICollection<Data.Role> getRoles()
        {
            ICollection<Data.Role> lstRoles = new List<Data.Role>();

            using (refRatesWeb.RateSysClient call = new refRatesWeb.RateSysClient())
            {
                ICollection<refRatesWeb.Role> Roles = call.Roles();

                if (Roles.Count > 0)
                {
                    foreach (refRatesWeb.Role r in Roles)
                    {
                        Data.Role role = new Data.Role()
                        {
                            RoleID = r.RoleID,
                            RoleName = r.RoleName,
                            RateID = r.RateID,
                        };
                        
                        lstRoles.Add(role);
                    }
                }

                return lstRoles;
            }
        }

        public static ICollection<Data.Rate> getRates()
        {
            ICollection<Data.Rate> lstRate = new List<Data.Rate>();

            using (refRatesWeb.RateSysClient call = new refRatesWeb.RateSysClient())
            {
                ICollection<refRatesWeb.Rate> Rates = call.Rates();

                if (Rates.Count > 0)
                {
                    foreach (refRatesWeb.Rate r in Rates)
                    {
                        Data.Rate rate = new Data.Rate() 
                        { 
                            RateID = r.RateID,
                            RateDescription = r.RateDescription,
                            Value = r.Value,
                        };
                        
                        lstRate.Add(rate);
                    }
                }
                return lstRate;
            }
        }

        public static bool addEmployee(string EmployeeName, string EmployeeSurname, string EmployeeNumber, int RoleID)
        {
            using (refRatesWeb.RateSysClient call = new refRatesWeb.RateSysClient())
            {
                refRatesWeb.Employee emp = new refRatesWeb.Employee();
                emp.EmployeeName = EmployeeName;
                emp.EmployeeSurname = EmployeeSurname;
                emp.EmployeeNumber = EmployeeNumber;
                emp.RoleID = RoleID;

                return call.AddEmployee(emp);
            }
        }

        public static bool addRate(string RateDescription, decimal RateValue)
        {
            using (refRatesWeb.RateSysClient call = new refRatesWeb.RateSysClient())
            {
                refRatesWeb.Rate rate = new refRatesWeb.Rate();
                rate.RateDescription = RateDescription;
                rate.Value = RateValue;

                return call.AddRate(rate);
            }
        }

        public static bool addRole(string RoleName, int RateID)
        {
            using(refRatesWeb.RateSysClient call = new refRatesWeb.RateSysClient())
            {
                refRatesWeb.Role role = new refRatesWeb.Role();
                role.RoleName = RoleName;
                role.RateID = RateID;

                return call.AddRole(role);
            }
        }
    }
}
