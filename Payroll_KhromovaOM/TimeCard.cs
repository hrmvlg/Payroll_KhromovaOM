using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class TimeCard
    {
        private readonly DateTime date;
        private readonly double hours;

        public TimeCard(DateTime date, double hours)
        {
            this.date = date;
            this.hours = hours;
        }

        public double Hours
        {
            get => hours;
        }

        public DateTime Date
        {
            get => date;
        }


    }
}
