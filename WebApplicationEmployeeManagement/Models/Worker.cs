using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationEmployeeManagement.Models
{
    public class Worker:Person
    {

        public int WorkingHour { get; set; }
        public decimal Rate { get; set; }

        public decimal PaidAmount()
        {
            return WorkingHour * Rate;
        }
    }
}