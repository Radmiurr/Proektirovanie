using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementSystem;

namespace ConsoleApp2
{
    //[Table("KitchenWorkers")]
    public class KitchenWorker : Employee
    {
        public int HoursWorked { get; set; }
    }
}
