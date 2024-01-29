using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L2
{
    internal class Management
    {
        public List<Employee> employeeList= new List<Employee>();
        public Management()
        {
            Console.WriteLine("Welcome, Admin!\n");
        }
//        a.Fill a list with objects based on the supplied data file.
        public void GenerateList()
        {
            Console.WriteLine("Generating employee list...");
            //read each line from employees.txt
            string filePath = @"C:\Users\School\source\repos\L2\res\employees.txt";
            int employeeCount = 1;
            int skipped = 0;
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] info = line.Split(':'); //seperate attributes by :
                long sin = long.Parse(info[4]); //make sin a long
                double pay = double.Parse(info[7]);//sake salary a double
                char idType = info[0][0]; // for checking employee type
                if ((idType >= '0') && (idType <= '4')) //send to salary
                {
                    Employee emp = new Salary(info[0], info[1], info[2], info[3], sin, info[5], info[6], pay);
                    employeeList.Add(emp);
                    employeeCount++;
                    continue;
                }
                else if ((idType >= '5') && (idType <= '7')) // send to wage
                {
                    double hours = double.Parse(info[8]);
                    Employee emp = new Wage(info[0], info[1], info[2], info[3], sin, info[5], info[6], pay, hours);
                    employeeList.Add(emp);
                    employeeCount++;
                    continue;
                }
                else if ((idType >= '8') && (idType <= '9')) // send to PT
                {
                    double hours = double.Parse(info[8]);
                    Employee emp = new PartTime(info[0], info[1], info[2], info[3], sin, info[5], info[6], pay, hours);
                    employeeList.Add(emp);
                    employeeCount++;
                    continue;
                }
                else
                {
                    Console.WriteLine($"Error, employe {employeeCount} not formatted correctly, skipping");
                    employeeCount++;
                    skipped++;
                    continue;
                }
            }
            if (skipped > 0)
            {
                Console.WriteLine("Partial list generated.");
                Console.WriteLine($"{skipped} out of {employeeCount-1} employees could not be added to list\n");
                return;
            }
            Console.WriteLine($"List generted successfully\nall {employeeCount-1} employees added to list.\n");

        }
        public void FindAveragePay()
        {
            Console.WriteLine("Calculating average pay for all employees this week...");
            double totalPay = 0; // running total
            foreach (Employee employee in employeeList) // iterate through list
            {
                totalPay += employee.GetPay(); // calc and add pay to total
            }
            double average = totalPay / employeeList.Count; // devide by length of list
            Console.WriteLine($"The average weekly pay this week is {average:c}\n"); // return result
        }
        public void FindHighestWage()
        {
            if ( employeeList.Count == 0)
            {
                Console.WriteLine("Error, list not populated");
                return;
            }
            Console.WriteLine("Finding highest paid WAGE employee this week...");
            //look at all emps
            double highWage = 0;
            Employee highEarner = employeeList[0];
            foreach (Employee employee in employeeList) // go through employee list
            {
                if (employee is Wage) // find wage employees
                {
                    double wage = employee.GetPay(); // calc pay
                    if (wage > highWage) // compare pay to current highest
                    {
                        highWage = wage; // replace highPay
                        highEarner = employee; //store OBJ pointer
                    }
                }
            }
            Console.WriteLine($"{highEarner.GetName()} had the highest WAGE this week at: {highWage:c}");
            Console.WriteLine(highEarner);

        }
        public void FindLowestSalary()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("Error, list not populated");
                return;
            }
            Console.WriteLine("Finding lowest paid SALARY employee...");
            bool firstFound = false;
            double lowSalary = 0;
            Employee lowEarner = employeeList[0];
            foreach (Employee employee in employeeList)
            {
                if (employee is Salary)
                {
                    double pay = employee.GetPay();
                    if (!firstFound)
                    {
                        firstFound = true;
                        lowSalary = pay;
                        lowEarner = employee;
                        continue;
                    }
                    if (pay < lowSalary)
                    {
                        lowSalary = pay;
                        lowEarner = employee;
                    }

                }
            }
            Console.WriteLine($"{lowEarner.GetName()} has the lowest SALARY, They earned {lowSalary:c} this week.");
            Console.WriteLine(lowEarner);
        }
        public void EmployeeStats()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("Error, list not populated");
                return;
            }
            Console.WriteLine("Generating employee statistics");
            double salaryTotal = 0; // keep total of each employee type
            double wageTotal = 0;
            double ptTotal = 0;
            foreach (Employee employee in employeeList)
            {
                if (employee is Salary) // increment salary
                {
                    salaryTotal++;
                }
                else if (employee is Wage) // increment wage
                {
                    wageTotal++;
                }
                else // increment PT
                {
                    ptTotal++;
                }
            }
            
            int population = employeeList.Count; // calculate percentages
            double salaryPercent = (salaryTotal/population)*100;
            double wagePercent = (wageTotal/population)*100;
            double ptPercent = (ptTotal/population)*100;
            Console.WriteLine($"{salaryPercent:F2}% of the company is SALARY\n"+
                $"{wagePercent:F2}% of the company is WAGE\n"+
                $"{ptPercent:F2}% of the company is PART TIME\n");
        }           
    }
}
