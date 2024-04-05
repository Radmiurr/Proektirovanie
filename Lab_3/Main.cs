using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornai_3
{
    class Program
    {
        static void Main()
        {
            // Создание сотрудников
            KitchenWorker kitchenWorker1 = new KitchenWorker { Name = "Женя", HireDate = new DateTime(2021, 1, 15), Salary = 10, HoursWorkedThisMonth = 160 };
            KitchenWorker kitchenWorker2 = new KitchenWorker { Name = "Мигель", HireDate = new DateTime(2019, 5, 20), Salary = 12, HoursWorkedThisMonth = 140 };

            Garcon garcon1 = new Garcon { Name = "Алексей", HireDate = new DateTime(2020, 4, 10), Salary = 8, HoursWorkedThisMonth = 160, TipsThisMonth = 500 };
            Garcon garcon2 = new Garcon { Name = "Софа", HireDate = new DateTime(2018, 8, 25), Salary = 7, HoursWorkedThisMonth = 150, TipsThisMonth = 400 };

            Manager manager = new Manager { Name = "Миша", HireDate = new DateTime(2017, 3, 5), Salary = 20, Bonus = 500, YearsWorked = 7 };

            JuniorManager juniorManager = new JuniorManager { Name = "Олег", HireDate = new DateTime(2016, 6, 10), Salary = 20, SemiAnnualBonus = 100, YearsWorked = 8 };

            // Вывод информации и зарплаты
            kitchenWorker1.GetInfo();
            kitchenWorker1.GetPrice();
            Console.WriteLine();

            kitchenWorker2.GetInfo();
            kitchenWorker2.GetPrice();
            Console.WriteLine();

            garcon1.GetInfo();
            garcon1.GetPrice();
            Console.WriteLine();

            garcon2.GetInfo();
            garcon2.GetPrice();
            Console.WriteLine();

            manager.GetInfo();
            manager.GetPrice();
            Console.WriteLine();

            juniorManager.GetInfo();
            juniorManager.GetPrice();
            Console.ReadLine();
        }
    }
}
