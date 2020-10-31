using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public abstract class ChangeEmployeeTransaction : Transaction
    {
        private readonly int empid;

        protected ChangeEmployeeTransaction(int empid)
        {
            this.empid = empid;
        }
   
        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empid);
            if (e != null)
                Change(e);
            else
                throw new InvalidOperationException("Работник не найден");
        }

        protected abstract void Change(Employee e);
    }
}
