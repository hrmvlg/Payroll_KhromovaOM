using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    class MailMethod : PaymentMethod
    {
        private readonly string address;

        public MailMethod(string address)
        {
            this.address = address;
        }

        public override string ToString()
        {
            return "Mail";
        }
    }
}
