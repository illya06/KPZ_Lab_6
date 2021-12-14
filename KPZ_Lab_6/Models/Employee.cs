using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_6.Models
{
    public partial class Employee
    {
        public int EmpNo { get; set; }
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public string DeptNo { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
    }
}
