using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        protected ChangeMethodTransaction(int empid) : base(empid)
        {
        }

        public abstract PaymentMethod Method { get; }
        

        protected override void Change(Employee e)
        {
            e.Method = Method;
        }
    }
}
