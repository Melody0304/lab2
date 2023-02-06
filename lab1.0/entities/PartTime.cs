using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._0.entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate
        {
            get { return rate; }
        }

        public double Hours
        { 
            get { return hours; }
        }

        public override double Pay
        {
            get => rate * hours;
        }
        public PartTime(string id, string name, string address, string phone, long sin, string birthday, string department, double rate, double hours) : base(id, name, address, phone, sin, birthday, department)
        {
            this.rate = rate;
            this.hours = hours;
        }
    }
}

