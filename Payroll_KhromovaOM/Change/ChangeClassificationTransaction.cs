using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        public ChangeClassificationTransaction(int empid) : base(empid)
        {
        }

        public abstract PaymentClassification Classification { get; }
        public abstract PaymentSchedule Schedule { get; }

        protected override void Change(Employee e)
        {
            e.Classification = Classification;
            e.Schedule = Schedule;
        }
    }
}
