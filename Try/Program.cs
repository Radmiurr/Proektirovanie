using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Threading;



class Teacher
{
    private string email;
    private string name;
    private int age;
    private string[] students;
    public string emailinfo = ("Почта коррректная");
    public string nameinfo = ("Имя коррректное");
    public string ageinfo = ("Возраст коррректный");

    public Teacher(string email, string name, int age, string[] students)
    {
        try
        {
            // Проверка почты
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                LogError("Почта содержит некорректный формат.");
            }
            this.email = email;

            // Проверка имени
            if (!Regex.IsMatch(name, @"^[А-Яа-я]+$"))
            {
                LogError("Имя содержит некорректные символы.");
            }
            this.name = name;

            // Проверка возраста
            if (age <= 0 || age > 120)
            {
                LogError("Некорректный возраст.");
            }
            this.age = age;

            this.students = students;
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Создание объекта завершено.");
        } 
    }

    private void LogError(string errorMessage)
    {
        string logMessage = $"Время ошибки: {DateTime.Now}\nОшибка: {errorMessage}\n";
        File.AppendAllText("errorLog.txt", logMessage);
    }
}




namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] students1 = { "Леша", "Вова", "Максим" };
            Teacher teacher = new Teacher("raida.mskgmail.com", "РаидаG", -1, students1);
            Thread.Sleep(3000);
            Teacher teacher2 = new Teacher("raida.msk@gmail.com", "Раида", 30, students1);
            Console.ReadLine();
        }
    }
}

