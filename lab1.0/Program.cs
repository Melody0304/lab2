using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1._0.entities;
using Lab2.Entities;

namespace lab1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //a
            string path = "employees.txt";

            string[] Lines;

            Lines = File.ReadAllLines(path);

            List<Employee> employees = new List<Employee>();

            foreach (string line in Lines)
            {
                string[] parts;

                parts = line.Split(':');

                string id = parts[0];

                string name = parts[1];

                string address = parts[2];

                string phone = parts[3];

                long sin = long.Parse(parts[4]);

                string birthday = parts[5];

                string department = parts[6];

                string firstDigit;

                firstDigit = id.Substring(0, 1);

                int firstDigitNum = int.Parse(firstDigit);

                if (firstDigitNum >= 0 && firstDigitNum <= 4)
                {
                    // Salaried
                    double salary = double.Parse(parts[7]);
                    employees.Add(new Salaried(id, name, address, phone, sin, birthday, department, salary));
                }
                else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                {
                    // Part time
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    employees.Add(new PartTime(id, name, address, phone, sin, birthday, department, rate, hours));
                }
                else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                {
                    // Wage
                    double rate = double.Parse(parts[7]);
                    double hours = double.Parse(parts[8]);
                    employees.Add(new Wages(id, name, address, phone, sin, birthday, department, rate, hours));
                }
            }
            double weekPaySum = 0;
            foreach (var employee in employees)
            {
                weekPaySum += employee.Pay;
            }
            Console.WriteLine($"The average weekly pay: {weekPaySum / employees.Count:C2}");

            //c
            double highestWage = 0;
            Employee highestEmployee = null;
            foreach (var employee in employees)
            {
                if (employee is Wages waged)
                {
                    if (waged.Pay > highestWage)
                    {
                        highestWage = employee.Pay;
                        highestEmployee = employee;
                    }
                }
            }
            Console.WriteLine($"The highest weekly pay is {highestWage:C2} for {highestEmployee.Name}");

            //d
            Employee lowestEmployee = findLowestSalary(employees);
            Console.WriteLine($"The lowest weekly pay is {lowestEmployee.Pay:C2} for {lowestEmployee.Name}");

            //e
            int salariedSum = 0;
            int wagedSum = 0;
            int partTimeSum = 0;
            foreach (var employee in employees)
            {
                if (employee is Salaried) { salariedSum++; }
                else if (employee is Wages) { wagedSum++; }
                else if (employee is PartTime) { partTimeSum++; }
            }
            Console.WriteLine($"The percentage of employees Salaried in the company: {(float)salariedSum / employees.Count * 100:N2}%\n" +
                $"The percentage of employees Waged in the company:: {(float)wagedSum / employees.Count * 100:N2}%\n" +
                $"The percentage of employees PartTime in the company:: {(float)partTimeSum / employees.Count * 100:N2}%");
        }

        public static Employee findLowestSalary(List<Employee> employees)
        {
            double lowestSalary = double.MaxValue;
            Employee lowestEmployee = null;
            foreach (var employee in employees)
            {
                if (employee is Salaried salaried)
                {
                    if (salaried.Pay < lowestSalary)
                    {
                        lowestSalary = employee.Pay;
                        lowestEmployee = employee;
                    }
                }
            }
            return lowestEmployee;
        }
    }
}
