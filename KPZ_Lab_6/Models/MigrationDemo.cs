using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ_Lab_6.Models
{
    public class MigrationDemo
    {
        [Key]
        public string MigrationNum { get; set; }    
        public string MigrationDemoName { get; set; }
    }
}
