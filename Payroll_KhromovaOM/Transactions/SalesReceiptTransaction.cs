using Payroll_KhromovaOM.Commissioned;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class SalesReceiptTransaction
    {
        private readonly DateTime date;
        private readonly double amound;
        private readonly int empid;

        public SalesReceiptTransaction(DateTime date, double amound, int empid)
        {
            this.date = date;
            this.amound = amound;
            this.empid = empid;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empid);
            if (e != null)
            {
                CommisionedClassification cc = e.Classification as CommisionedClassification;
                if (cc != null)
                {
                    cc.AddSalesReceipt(new SalesReceipt(date, amound));
                }
                else
                    throw new InvalidOperationException("");
            }
            else
                throw new InvalidOperationException("");
        }
    }
}
