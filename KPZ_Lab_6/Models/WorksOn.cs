using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_Lab_6.Models
{
    public partial class WorksOn
    {
        public int EmpNo { get; set; }
        public string ProjectNo { get; set; }
        public string Job { get; set; }
        public string EnterDate { get; set; }

        public virtual Employee EmpNoNavigation { get; set; }
        public virtual Project ProjectNoNavigation { get; set; }
    }
}
