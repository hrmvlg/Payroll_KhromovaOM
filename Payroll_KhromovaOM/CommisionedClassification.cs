using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM.Commissioned
{
    public class CommisionedClassification : PaymentClassification
    {
        private readonly double salary;
        private readonly double commisionRate;

        public CommisionedClassification(double salary, double commisionRate)
        {
            this.salary = salary;
            this.commisionRate = commisionRate;
        }

        public double Salary
        {
            get => salary;
        }

        public double CommisionRate
        {
            get => commisionRate;
        }


        public override string ToString()
        {
            return String.Format("${0}, cr:{1}%", salary, commisionRate);
        }
    }
}
