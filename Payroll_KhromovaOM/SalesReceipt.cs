using System;

namespace Payroll_KhromovaOM
{
    public class SalesReceipt
    {
        private readonly DateTime date;
        private readonly double amound;

        public SalesReceipt(DateTime date, double amound)
        {
            this.date = date;
            this.amound = amound;
        }

        public DateTime Date { get => date; }
        public double Amound { get => amound; }
    }
}