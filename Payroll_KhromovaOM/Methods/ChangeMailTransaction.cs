using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    class ChangeMailTransaction : ChangeMethodTransaction
    {
        private readonly string address;

        public ChangeMailTransaction(int empid, string address) : base(empid) => this.address = address;

        public override PaymentMethod Method => new MailMethod(address);
    }
}
