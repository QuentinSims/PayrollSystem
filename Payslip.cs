using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PayrollSystem
{
    class Payslip
    {
        //fields
        private int _month;
        private int _year;

        //enum
        enum MonthsOfYear
        {
            Jan = 1, Feb = 2, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        }

        //constructor
        public Payslip(int payMonth, int payYear)
        {
            _month = payMonth;
            _year = payYear;
        }

        //methods
        public void GeneratePaySlip(List<Staff> staffs)
        {
            string path;
            foreach (Staff staff in staffs)
            {
                path = staff._nameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP for {0} {1}", (MonthsOfYear)_month, _year);
                    sw.WriteLine("===========================");
                    sw.WriteLine("Name of Staff: {0}", staff._nameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", staff._hoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", staff._basicPay);

                    if (staff.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowances: {0:C}", ((Manager)staff)._allowance);
                    }
                    else
                    {
                        sw.WriteLine("OverTime: {0:C}", ((Admin)staff)._overtime);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("==============================");
                    sw.WriteLine("Total Pay: {0:C}", staff._totalPay);
                    sw.WriteLine("===============================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> staffs)
        {
            var result =
                from staff in staffs
                where staff._hoursWorked < 10
                orderby staff._nameOfStaff ascending
                select new { staff._nameOfStaff, staff._hoursWorked };

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var staff in result)
                {
                    sw.WriteLine("Name of Staff: {0}, " +
                        "Hours worked: {1}", staff._nameOfStaff, staff._hoursWorked);
                }

                sw.Close();
            }

        }
        public override string ToString()
        {
            return $"month: {_month}, year: {_year}.";
        }

    }
}
