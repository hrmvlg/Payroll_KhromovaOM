using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class DirectDepositMethod : PaymentMethod
    {
       private readonly string bank;
       private readonly string account;

        public DirectDepositMethod(string bank, string account)
        {
            this.bank = bank;
            this.account = account;
        }

        public override string ToString()
        {
            return "Direct Deposi";
        }
    }
}