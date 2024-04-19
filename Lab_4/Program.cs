using System;
using System.Collections.Generic;
using ConsoleApp1;

namespace console.app
{
    public class Employee
    {
        public int Id;
        public string Name;
        public string Position;
        public decimal Salary;
        public int HoursWorked;
        public int Seniority;
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Employee> employees = SqlManager.GetEmployees();

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Имя: {employee.Name}");
                Console.WriteLine($"Должность: {employee.Position}");
                Console.WriteLine($"Зарплата: {employee.Salary}");
                Console.WriteLine($"Отработанные часы в месяце: {employee.HoursWorked}");
                Console.WriteLine($"Стаж: {employee.Seniority}");
                if (employee.Position == "Менеджер"){
                    int bonus = 300;
                    decimal salary = (employee.Salary + bonus) * employee.Seniority;
                    Console.WriteLine($"Заработная плата за месяц: {salary}");
                }
                if (employee.Position == "Повар")
                {
                    decimal salary = employee.Salary * employee.HoursWorked;
                    Console.WriteLine($"Заработная плата за месяц: {salary}");
                }
                if (employee.Position == "Официант")
                {
                    int tips = 150;
                    decimal salary = (employee.Salary * employee.HoursWorked) + tips;
                    Console.WriteLine($"Заработная плата за месяц: {salary}");
                }
                Console.WriteLine();
            }


        }
    }
}
