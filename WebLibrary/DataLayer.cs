using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using WebLibrary.Entities;

namespace WebLibrary.Data
{
    public class RatesDBContext : DbContext
    {
        public RatesDBContext() : base("RateDBConnectionString")
        {
            Database.SetInitializer<RatesDBContext>(new RatesDBInitializer());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(e => e.RoleID);
            modelBuilder.Entity<Rate>().HasKey(e => e.RateID);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);
            modelBuilder.Entity<Rate>().HasMany<Role>(r => r.Roles).WithRequired(r => r.Rate).HasForeignKey(s => s.RateID);
            modelBuilder.Entity<Role>().HasMany<Employee>(e => e.Employees).WithRequired(e => e.Role).HasForeignKey(e => e.RoleID);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class RatesDBInitializer : CreateDatabaseIfNotExists<RatesDBContext>
    {
        protected override void Seed(RatesDBContext context)
        {
            IList<Role> defaultRoles = new List<Role>();

            Rate rate = new Rate() { Value = 0.00M };

            context.Rates.Add(rate);

            defaultRoles.Add(new Role() { RoleName = ".Net Developer", Rate=rate});
            defaultRoles.Add(new Role() { RoleName = "Technical Team Lead", Rate = rate});
            defaultRoles.Add(new Role() { RoleName = "Scrum Master", Rate=rate});
            defaultRoles.Add(new Role() { RoleName = "Tester", Rate=rate});
            defaultRoles.Add(new Role() { RoleName = "Architect", Rate=rate});
            defaultRoles.Add(new Role() { RoleName = "Database Administrator", Rate=rate});
            defaultRoles.Add(new Role() { RoleName = "SharePoint Developer", Rate=rate});
            defaultRoles.Add(new Role() { RoleName = "BI Developer", Rate=rate});

            Employee emp = new Employee() { EmployeeName = "Default", EmployeeNumber = "0", EmployeeSurname = "Employee", Role=defaultRoles[0] };
            context.Employees.Add(emp);

            foreach (Role r in defaultRoles)
            {
                context.Roles.Add(r);
            }

            base.Seed(context);
        }
    }
}
