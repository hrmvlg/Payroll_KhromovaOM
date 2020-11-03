using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    class ChangeHoldTransaction : ChangeMethodTransaction
    {
        public ChangeHoldTransaction(int empid) : base(empid){ }

        public override PaymentMethod Method => new HoldMethod();
    }
}
