using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem;

namespace ConsoleApp2
{
    //[Table("Garcons")]
    public class Garcon : Employee
    {
        public int HoursWorkedThisMonth { get; set; }
        public int TipsThisMonth { get; set; }
    }
}
