using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
     public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private readonly string newAddress;

        public ChangeAddressTransaction(int empid, string newAddress) : base(empid)
        {
            this.newAddress = newAddress;
        }

        protected override void Change(Employee e)
        {
            e.Address = newAddress;
        }
    }
}
