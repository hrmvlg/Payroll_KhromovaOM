using Payroll_KhromovaOM.Hourly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly double hourlyRate;

        public ChangeHourlyTransaction(int empid, double hourlyRate) : base(empid)
        {
            this.hourlyRate = hourlyRate;
        }

        public override PaymentClassification Classification => new HourlyClassification(hourlyRate);

        public override PaymentSchedule Schedule => new WeeklySchedule();
    }
}

