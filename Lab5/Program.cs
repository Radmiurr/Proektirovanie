using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2;

namespace EmployeeManagementSystem
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }


    public class EmployeeContext : DbContext
    {
        //public EmployeeContext() => Database.EnsureCreated();
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<KitchenWorker> KitchenWorkers { get; set; } = null!;
        public DbSet<Manager> Managers { get; set; } = null!;
        public DbSet<Garcon> Garcons { get; set; } = null!;

        public  EmployeeContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
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
                Manager manager1 = new Manager { Name = "Иван Иванов", Position = "Менеджер", Salary = 20, Bonus = 300, YearsWorked = 5 };
                Garcon garcon1 = new Garcon { Name = "Софа", Position = "Официант", Salary = 7, TipsThisMonth= 150, HoursWorkedThisMonth= 150 };
                KitchenWorker employee3 = new KitchenWorker { Name = "Женя", Position = "Повар", Salary = 10, HoursWorked=160 };
                KitchenWorker employee4 = new KitchenWorker { Name = "Мигель", Position = "Повар", Salary = 12, HoursWorked=140 };
                db.Managers.Add(manager1);
                db.Garcons.Add(garcon1);
                db.KitchenWorkers.Add(employee3);
                db.KitchenWorkers.Add(employee4);

                db.SaveChanges();

                Console.WriteLine("\n Все работники кухни");
                foreach (var kw in db.KitchenWorkers.ToList())
                {
                    Console.WriteLine("Имя: {0}", kw.Name);
                    Console.WriteLine("Должность: {0}", kw.Position);
                    Console.WriteLine("Зарплата: {0}", kw.Salary);
                    decimal salary = kw.Salary * kw.HoursWorked;
                    Console.WriteLine($"Заработная плата за месяц: {salary}");
                }

                Console.WriteLine("\n Все официанты");
                foreach (var gar in db.Garcons.ToList())
                {
                    Console.WriteLine("Имя: {0}", gar.Name);
                    Console.WriteLine("Должность: {0}", gar.Position);
                    Console.WriteLine("Зарплата: {0}", gar.Salary);
                    decimal salary = (gar.Salary * gar.HoursWorkedThisMonth) + gar.TipsThisMonth;
                    Console.WriteLine($"Заработная плата за месяц: {salary}");
                }
                Console.WriteLine("\n Все менеджеры");
                foreach (var man in db.Managers.ToList())
                {
                    Console.WriteLine("Имя: {0}", man.Name);
                    Console.WriteLine("Должность: {0}", man.Position);
                    Console.WriteLine("Зарплата: {0}", man.Salary);
                    decimal salary = (man.Salary + man.Bonus) * man.YearsWorked;
                    Console.WriteLine($"Заработная плата за месяц: {salary}");
                }
                Console.WriteLine();

                //var employees = db.Employees.ToList() + db.Employees.ToList() + db.Employees.ToList();
                //Console.WriteLine("Список объектов:");

                //foreach (var employee in employees)
                //{
                //    Console.WriteLine("Имя: {0}", employee.Name);
                //    Console.WriteLine("Должность: {0}", employee.Position);
                //    Console.WriteLine("Зарплата: {0}", employee.Salary);
                //    if (employee.Position == "Менеджер")
                //    {
                //        //int bonus = 300;
                //        decimal salary = (employee.Salary + employee.Bonus) * employee.Seniority;
                //        Console.WriteLine($"Заработная плата за месяц: {salary}");
                //    }
                //    if (employee.Position == "Повар")
                //    {
                //        decimal salary = employee.Salary * employee.HoursWorked;
                //        Console.WriteLine($"Заработная плата за месяц: {salary}");
                //    }
                //    if (employee.Position == "Официант")
                //    {
                //        int tips = 150;
                //        decimal salary = (employee.Salary * employee.TipsThisMonth) + tips;
                //        Console.WriteLine($"Заработная плата за месяц: {salary}");
                //    }
                //    Console.WriteLine();
                //}

                //db.Database.EnsureDeleted();
            }
        }
    }

}