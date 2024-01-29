using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    public class PartTime:Employee
    {
        private double Pay { get; set; }
        private double HoursWorked { get; set; }

        public PartTime() : base()
        {
            this.Pay = 0;
            this.HoursWorked = 0;
        }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double salary, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Pay = salary;
            this.HoursWorked = hours;
        }
        public override double GetPay()
        {
            //just pay*hours, no OT rate
            double weekPay = (this.Pay*this.HoursWorked);
            return weekPay;
        }
        public override string ToString()
        {
            return $"\tThis is a Part Time employee.\n" +
                $"{base.ToString()}" +
                $"\tHourly Rate: {this.Pay:c}\n" +
                $"\tHours worked this week: {this.HoursWorked}\n";
        }
    }
}
