using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class SalariedClassification : PaymentClassification
    {
        private readonly double salary;

        public SalariedClassification(double salary)
        {
            this.salary = salary;
        }

        public double Salary
        {
            get => salary;
        }

        public override string ToString()
        {
            return String.Format("${0}", salary);
        }
    }
}
