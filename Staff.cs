using System;

namespace PayrollSystem
{
    class Staff
    {
        //fields
        private float _hourlyRate;

        private int _hWorked;

        //properties
        public float _totalPay { get; protected set; }
        public float _basicPay { get; private set; }
        public string _nameOfStaff { get; private set; }
        public int _hoursWorked
        {
            get { return _hWorked; }
            set
            {
                if (value > 0)
                {
                    _hWorked = value;
                }
                else
                {
                    _hWorked = 0;
                }
            }
        }

        //constructor
        public Staff(string name, float rate)
        {
            _nameOfStaff = name;
            _hourlyRate = rate;
        }

        //methods
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculaitng Pay...");
            _basicPay = _hWorked * _hourlyRate;
            _totalPay = _basicPay;
        }
        public override string ToString()
        {
            return $"staff member: {_nameOfStaff}, hourly rate: {_hourlyRate}," +
                $"hours worked: {_hoursWorked}, Basic pay: {_basicPay}" +
                $"Total Pay: {_totalPay}.";
        }


    }
}
