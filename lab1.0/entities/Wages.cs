using lab1._0.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Wages : Employee
    {
        private double rate;
        private double hours;

        public double Rate { get => rate; }
        public double Hours { get => hours; }
        public override double Pay
        {
            get
            {
                double overtimeThresholds = 40;
                if (hours > overtimeThresholds)
                {
                    return rate * overtimeThresholds + (hours - overtimeThresholds) * rate * 1.5;
                }
                else
                {
                    return rate * hours;
                }
            }
        }

        public Wages(string id, string name, string address, string phone, long sin, string birthday, string department, double rate, double hours) : base(id, name, address, phone, sin, birthday, department)
        {
            this.rate = rate;
            this.hours = hours;
        }
    }
}

