using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace WebApplicationEmployeeManagement.ViewModel
{
    public class EmployeeInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }

    }
}