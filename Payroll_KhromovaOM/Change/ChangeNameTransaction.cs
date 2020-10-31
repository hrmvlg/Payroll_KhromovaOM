using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private readonly string newName;

        public ChangeNameTransaction(int empid, string newName) : base(empid)
        {
            this.newName = newName;
        }

        protected override void Change(Employee e)
        {
            e.Name = newName;
        }
    }
}
