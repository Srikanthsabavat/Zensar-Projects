using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeDetails.Models
{
    public class MyClassContext: DbContext
    {
        public MyClassContext() : base("name=Emp")
        {

        }
        public DbSet <MyClass> employee
        { get; set; }

    }
}