using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationEmployeeManagement.Models
{
    public class Employee:Person
    {
        public decimal Salary { get; set; }

        [ForeignKey("Designation")]
        public int DesignationID { get; set; }
        public virtual Designation Designation { get; set; }
    }
}