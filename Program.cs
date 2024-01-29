using System.Collections.Generic;
using System.Xml.Linq;
//Chloe Nibali - 000913397
//Lab2 - CPRG 211 - E
namespace L2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program start, Welcome!!");
            Management admin = new Management();
            admin.GenerateList();
            admin.FindAveragePay();
            admin.FindHighestWage();
            admin.FindLowestSalary();
            admin.EmployeeStats();
            Console.WriteLine("Program end, Goodbye!");
        }
    }
}
