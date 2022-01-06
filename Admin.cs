namespace PayrollSystem
{
    class Admin : Staff
    {
        //fields
        private const float _overTimeRate = 15.5f;
        private const float _adminHourlyRate = 30;

        //properties
        public float _overtime { get; private set; }
        public Admin(string name) :
            base(name, _adminHourlyRate)
        {

        }

        //method
        public override void CalculatePay()
        {
            base.CalculatePay();
            if (_hoursWorked > 160)
            {
                _overtime = _overTimeRate * (_hoursWorked - 160);
            }
        }

        public override string ToString()
        {
            return $"staff member: {_nameOfStaff}, Admin hourly rate: {_adminHourlyRate}," +
                $"hours worked:{_hoursWorked}, Basic pay: {_basicPay}, overtime: {_overtime}," +
                $"Total Pay: {_totalPay}.";
        }

    }
}
