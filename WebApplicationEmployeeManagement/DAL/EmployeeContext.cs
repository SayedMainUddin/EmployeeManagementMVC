using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplicationEmployeeManagement.Models;

namespace WebApplicationEmployeeManagement.DAL
{
    public class EmployeeContext : DbContext
    {

        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public EmployeeContext():base("DbConnection")
        {

        }

    }
}