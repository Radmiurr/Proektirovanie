using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int HoursWorked { get; set; }
        public int Seniority { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext() => Database.EnsureCreated();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                Employee employee1 = new Employee { Name = "Иван Иванов", Position = "Менеджер", Salary = 20, HoursWorked = 160, Seniority = 5 };
                Employee employee2 = new Employee { Name = "Софа", Position = "Официант", Salary = 7, HoursWorked = 150, Seniority = 3 };
                Employee employee3 = new Employee { Name = "Женя", Position = "Повар", Salary = 10, HoursWorked = 160, Seniority = 2 };
                Employee employee4 = new Employee { Name = "Мигель", Position = "Повар", Salary = 12, HoursWorked = 140, Seniority = 1 };
                db.Employees.Add(employee1);
                db.Employees.Add(employee2);
                db.Employees.Add(employee3);
                db.Employees.Add(employee4);

                db.SaveChanges();

                var employees = db.Employees.ToList();
                Console.WriteLine("Список объектов:");

                foreach (var employee in employees)
                {
                    Console.WriteLine("Имя: {0}", employee.Name);
                    Console.WriteLine("Должность: {0}", employee.Position);
                    Console.WriteLine("Зарплата: {0}", employee.Salary);
                    Console.WriteLine("Количество отработанных часов в месяце: {0}", employee.HoursWorked);
                    Console.WriteLine("Стаж: {0}", employee.Seniority);
                    if (employee.Position == "Менеджер")
                    {
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

                db.Database.EnsureDeleted();
            }
        }
    }

}