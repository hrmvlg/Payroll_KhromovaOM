using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class CommisionedClassification : PaymentClassification
    {
        private readonly double salary;
        private readonly double commisionRate;
        private Hashtable salesReceipt = new Hashtable();

        public CommisionedClassification(double salary, double commisionRate)
        {
            this.salary = salary;
            this.commisionRate = commisionRate;
        }

        public SalesReceipt GetSalesReceipt(DateTime date)
        {
            return salesReceipt[date] as SalesReceipt;
        }

        public void AddSalesReceipt(SalesReceipt receipt)
        {
            salesReceipt[receipt.Date] = receipt;
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
