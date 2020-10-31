using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {

        protected ChangeAffiliationTransaction(int empid) : base(empid) { }

        protected override void Change(Employee e)
        {
            RecordMembership(e);
            Affiliation affiliation = Affiliation;
            e.Affiliation = affiliation;
        }

        protected abstract void RecordMembership(Employee e);
        protected abstract Affiliation Affiliation { get; }
    }
}
