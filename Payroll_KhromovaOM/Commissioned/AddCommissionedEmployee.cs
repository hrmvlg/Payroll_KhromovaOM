using Payroll_KhromovaOM.Commissioned;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM.Add
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
        private readonly double salary;
        private readonly double commisionRate;

        public AddCommissionedEmployee(int id, string name, string address, double salary, double commisionRate)
            :base(id, name, address)
        {
            this.salary = salary;
            this.commisionRate = commisionRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new CommisionedClassification(salary, commisionRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
           return new BiweeklySchedule();
        }
    }
}
