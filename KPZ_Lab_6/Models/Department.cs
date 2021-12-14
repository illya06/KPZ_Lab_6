using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_6.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public string DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
