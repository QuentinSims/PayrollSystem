namespace PayrollSystem
{
    class Manager : Staff
    {
        //fields
        private const float _managerHourlyRate = 50;

        //properties
        public int _allowance { get; private set; }

        //constructor
        public Manager(string name) : base(name, _managerHourlyRate)
        {

        }

        //method
        public override void CalculatePay()
        {
            base.CalculatePay();
            _allowance = 1000;
            if (_hoursWorked > 160)
            {
                _totalPay = _basicPay + _allowance;
            }

        }
        public override string ToString()
        {
            return $"staff member: {_nameOfStaff}, Manager hourly rate: {_managerHourlyRate}," +
                $"hours worked: {_hoursWorked}, Basic pay: {_basicPay}" +
                $"Allowance: {_allowance}, Total Pay: {_totalPay}";
        }

    }
}
