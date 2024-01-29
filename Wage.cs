using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    public class Wage:Employee
    {
        private double Pay { get; set; }
        private double HoursWorked { get; set; }

        public Wage() : base()
        {
            this.Pay = 0;
            this.HoursWorked = 0;
        }
        public Wage(string id, string name, string address, string phone, long sin, string dob, string dept, double salary, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Pay = salary;
            this.HoursWorked = hours;
        }
        public override double GetPay()
        {
            // normal rat up to 40 hours
            // time and a half beyond that
            double normalHours = this.HoursWorked;
            double oTHours = 0;
            if (this.HoursWorked > 40) // check if worked more than 40 hours
            {
                normalHours = 40;
                oTHours = (this.HoursWorked - 40); // set overtime
            }
            double weekPay = (normalHours * this.Pay) + (oTHours*(this.Pay * 1.5));
            return weekPay;
        }
        public override string ToString()
        {
            return $"\tThis is a Wage employee.\n" +
                $"{base.ToString()}" +
                $"\tHourly Rate: {this.Pay:c}\n"+
                $"\tHours worked this week: {this.HoursWorked}\n";
        }
    }
}
