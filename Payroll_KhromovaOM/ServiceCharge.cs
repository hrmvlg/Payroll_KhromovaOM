using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ServiceCharge
    {
        private readonly DateTime date;
        private readonly double amound;
        private readonly double charge;

        public ServiceCharge(DateTime date, double amound)
        {
            this.date = date;
            this.amound = amound;
        }

        public DateTime Date { get => date; }
        public double Amound { get => amound; }
        public double Charge { get => charge; }
    }
}
