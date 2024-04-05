using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornai_3
{
    public class Manager : Employee
    {
        public int Bonus { get; set; }
        public int YearsWorked { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"Менеджер: {Name}, Отработал часов: {HireDate}");
        }

        public override void GetPrice()
        {
            decimal monthlySalary = (Salary + Bonus) * YearsWorked;
            Console.WriteLine($"Месячная ЗП: {monthlySalary}");
        }
    }
}
