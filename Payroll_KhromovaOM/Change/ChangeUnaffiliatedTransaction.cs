using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
    {
        public ChangeUnaffiliatedTransaction(int empid) : base(empid)
        {        }

       // protected override Affiliation Affiliation => new NoAffilation();
        protected override Affiliation Affiliation { get; }

        protected override void RecordMembership(Employee e)
        {
            Affiliation affiliation = e.Affiliation;
            if (affiliation is UnionAffilation)
            {
                UnionAffilation unionAffilation = affiliation as UnionAffilation;
                int memberId = unionAffilation.MemberId;
                PayrollDatabase.RemoveUnionMember(memberId);
            }
        }
    }
}
