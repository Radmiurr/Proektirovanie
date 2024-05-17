using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem;

namespace ConsoleApp2
{
    //[Table("Managers")]
    public class Manager : Employee
    {
        public int Bonus { get; set; }
        public int YearsWorked { get; set; }
    }
}
