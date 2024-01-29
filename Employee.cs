using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
{
    public class Employee
    {
        //member attributes
        private string Id { get; set; }
        private string Name { get; set; }
        private string Address { get; set; }
        private string Phone { get; set; }
        private long Sin { get; set; }
        private string DOB { get; set; }
        private string Department { get; set; }

        public Employee()
        {
            this.Id = "null";
            this.Name = "null";
            this.Address = "null";
            this.Phone = "null";
            this.Sin = 0;
            this.DOB = "null";
            this.Department = "null";
        }
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.Id= id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.DOB = dob;
            this.Department = dept;
        }
        public string GetName()
        {
            return this.Name;
        }
        public virtual double GetPay()
        {
            Console.WriteLine("Error, must specify employee type to calculate pay");
            return 0;
        }
        public override string ToString()
        {
            return $"\tID: {this.Id}\n" +
                $"\tName: {this.Name}\n" +
                $"\tAddress: {this.Address}\n" +
                $"\tPhone: {this.Phone}\n" +
                $"\tSin: ***-***-{this.Sin%1000}\n" + // mask SIN, its sensitive info
                $"\tDate of Birth: {this.DOB}\n" +
                $"\tDepartment: {this.Department}\n";
        }
    }
}
