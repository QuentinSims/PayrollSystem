using System;
using System.Collections.Generic;

namespace PayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("Please enter the year: ");
                string input = Console.ReadLine();
                try
                {
                    year = Convert.ToInt32(input);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Year entered was wrong format, {e}.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("Please enter the month: ");
                string input = Console.ReadLine();
                try
                {
                    month = Convert.ToInt32(input);
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("You have entered an invalid month, month must be" +
                            "from 1 to 12, try again");
                        month = 0;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Year entered was wrong format, {e}.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine($"Enter hours worked for {myStaff[i]._nameOfStaff}: ");
                    myStaff[i]._hoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    myStaff[i].ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e}");
                    i--;
                }
            }

            Payslip ps = new Payslip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();

        }
    }
}
