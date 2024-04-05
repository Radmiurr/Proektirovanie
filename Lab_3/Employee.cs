using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratornai_3
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        // Абстрактные методы
        public abstract void GetInfo();
        public abstract void GetPrice();
    }
}
