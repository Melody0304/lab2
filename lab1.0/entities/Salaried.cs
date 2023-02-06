using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._0.entities
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary
        {
            get { return salary; }
        }
        public override double Pay => salary;

        public Salaried(string id, string name, string address, string phone, long sin, string birthday, string department, double salary) : base(id, name, address, phone, sin, birthday, department)
        {
            this.salary= salary;
        }
    }
}

