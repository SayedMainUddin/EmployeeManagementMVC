using System.Collections.Generic;

namespace WebApplicationEmployeeManagement.Models
{
    public class Designation
    {

        public int DesignationID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}