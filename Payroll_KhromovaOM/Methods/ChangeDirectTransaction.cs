using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    class ChangeDirectTransaction : ChangeMethodTransaction
    {
        private readonly string bank;
        private readonly string account;

        public ChangeDirectTransaction(int empid, string bank, string account) : base(empid)
        {
            this.bank = bank;
            this.account = account;
        }

        public override PaymentMethod Method => new DirectDepositMethod(bank, account);
    }
}
