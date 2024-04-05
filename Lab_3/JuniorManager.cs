using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornai_3
{
    public class JuniorManager : Manager
    {
        public int SemiAnnualBonus { get; set; }

        public override void GetInfo()
        {
            Console.WriteLine($"Младший менеджер: {Name}, Отработал часов: {HireDate}");
        }

        public override void GetPrice()
        {
            if (DateTime.Today.Month == 6 || DateTime.Today.Month == 12)
            {
                decimal semiAnnualSalary = (Salary + SemiAnnualBonus) * YearsWorked;
                Console.WriteLine($"ЗП с Премией: {semiAnnualSalary}");
            }
            else
            {
                decimal monthlySalary = Salary * YearsWorked;
                Console.WriteLine($"Месячная ЗП: {monthlySalary}");
            }
        }
    }
}
