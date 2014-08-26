using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebLibrary.Entities;
using WebLibrary.Data;

namespace WebLibrary
{
    public class RateSystem:IRateSys
    {
        public RateSystem(){}

        public ICollection<Role> Roles()
        {
            Console.WriteLine("{0} - Getting Roles", DateTime.Now);
            ICollection<Role> Roles = new List<Role>();
            using (RatesDBContext context = new RatesDBContext())
            {
                foreach (Role role in context.Roles)
                {
                    Role r = new Role();
                    r.RoleName = role.RoleName;
                    r.RateID = role.RateID;
                    Roles.Add(r);
                    Console.WriteLine("Role Name : {0}", r.RoleName);
                }
            }

            return Roles;
        }

        public ICollection<Rate> Rates()
        {
            Console.WriteLine("{0} - Getting Rates", DateTime.Now);
            ICollection<Rate> Rate = new List<Rate>();
            using (RatesDBContext context = new RatesDBContext())
            {
                foreach (Rate rate in context.Rates)
                {
                    Rate r = new Rate();
                    r.RateID = rate.RateID;
                    r.Value = rate.Value;
                    Rate.Add(r);
                    Console.WriteLine("Rate Value : {0}", r.Value.ToString());
                }
                return Rate;
            }
        }

        public ICollection<Employee> Employees()
        {
            Console.WriteLine("{0} - Getting Employees", DateTime.Now);
            List<Employee> Employees = new List<Employee>();
            using(RatesDBContext context = new RatesDBContext())
            {
                foreach (Employee employee in context.Employees)
                {
                    Employee e = new Employee();
                    e.EmployeeID = employee.EmployeeID;
                    e.EmployeeName = employee.EmployeeName;
                    e.EmployeeNumber = employee.EmployeeNumber;
                    e.EmployeeSurname = employee.EmployeeSurname;
                    e.RoleID = employee.RoleID;
                    Employees.Add(e);
                    Console.WriteLine("Employee : {0} {1}", e.EmployeeName, e.EmployeeSurname);
                }

                return Employees;
            }
        }

        public bool AddEmployee(Employee emp)
        {
            Console.WriteLine("{0} - Adding Employee", DateTime.Now);
            using(RatesDBContext context = new RatesDBContext())
            {
                Role role = context.Roles.Where(r => r.RoleID == emp.RoleID).FirstOrDefault<Role>();
                if(role != null)
                {
                    context.Employees.Add(new Employee() { EmployeeName = emp.EmployeeName, EmployeeSurname = emp.EmployeeSurname, EmployeeNumber = emp.EmployeeNumber, Role = role });
                    context.SaveChanges();
                    Console.WriteLine("Employee Name : {0} To : {1}", emp.EmployeeName,role.RoleName);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool AddRate(Rate rate)
        {
            Console.WriteLine("{0} - Adding Rate", DateTime.Now);
            using(RatesDBContext context = new RatesDBContext())
            {
                context.Rates.Add(new Rate() { Value = rate.Value });
                context.SaveChanges();
                Console.WriteLine("Rate Value : {0}", rate.Value.ToString());

                return true;
            }
        }

        public bool AddRole(Role role)
        {
            Console.WriteLine("{0} - Adding Role", DateTime.Now);
            using(RatesDBContext context = new RatesDBContext())
            {
                Rate rate = context.Rates.Where(r => r.RateID == role.RateID).FirstOrDefault<Rate>();
                if (rate != null)
                {
                    context.Roles.Add(new Role() { RoleName = role.RoleName, Rate = rate });
                    context.SaveChanges();
                    Console.WriteLine("Role : {0} with rate : {1}",role.RoleName, rate.Value.ToString());

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
