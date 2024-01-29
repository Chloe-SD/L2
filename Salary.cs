using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    public class Salary:Employee
    {
        private double Pay {  get; set; }

        public Salary():base()
        {
            this.Pay = 0; 
        }
        public Salary(string id, string name, string address, string phone, long sin, string dob, string dept, double salary):base(id, name, address, phone, sin, dob, dept)
        {
            this.Pay = salary;
        }
        public override double GetPay()
        {
            //devide by 52 for weekly pay
            return (this.Pay / 52);
        }
        public override string ToString()
        {
            return $"\tThis is a Salaried employee.\n" +
                $"{base.ToString()}" +
                $"\tSalary: {this.Pay:c}\n";
        }

    }
}
