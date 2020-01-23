using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationEmployeeManagement.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public enum Gender
    {
        Male, Female
    }
}