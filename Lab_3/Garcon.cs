using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornai_3
{
    public class Garcon : Employee
    {
        public int HoursWorkedThisMonth { get; set; }
        public int TipsThisMonth { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"Официант: {Name}, Отработал часов: {HireDate}");
        }

        public override void GetPrice()
        {
            decimal monthlySalary = (Salary * HoursWorkedThisMonth) + TipsThisMonth;
            Console.WriteLine($"Месячная ЗП: {monthlySalary}");
        }
    }
}
