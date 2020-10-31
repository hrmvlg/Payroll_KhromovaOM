using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;

        public ChangeSalariedTransaction(int empid, double salary) : base(empid)
        {
            this.salary = salary;
        }

        public override PaymentClassification Classification => new SalariedClassification(salary);

        public override PaymentSchedule Schedule => new MothlySchedule();
    }
}
