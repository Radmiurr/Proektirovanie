using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornai_3
{
    public class KitchenWorker : Employee
    {
        public int HoursWorkedThisMonth { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"Работник кухни: {Name}, Отработал часов: {HireDate}");
        }

        public override void GetPrice()
        {
            decimal monthlySalary = Salary * HoursWorkedThisMonth;
            Console.WriteLine($"Месячная ЗП: {monthlySalary}");
        }
    }
}
