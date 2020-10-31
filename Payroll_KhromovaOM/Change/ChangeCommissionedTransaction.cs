using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;
        private readonly double commisionRate;

        public ChangeCommissionedTransaction(int empid, double salary, double commisionRate) : base(empid)
        {
            this.salary = salary;
            this.commisionRate = commisionRate;
        }

        public override PaymentClassification Classification => new CommisionedClassification(salary, commisionRate);

        public override PaymentSchedule Schedule => new BiweeklySchedule();
    }
}
