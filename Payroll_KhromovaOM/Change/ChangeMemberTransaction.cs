using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
   public class ChangeMemberTransaction : ChangeAffiliationTransaction
   {
        private readonly int memberId;
        private readonly double charge;

        public ChangeMemberTransaction(int empid, int memberId, double charge) : base(empid)
        {
            this.memberId = memberId;
            this.charge = charge;
        }

        protected override Affiliation Affiliation { get => new UnionAffilation(memberId, charge); }

        protected override void RecordMembership(Employee e)
        {
            PayrollDatabase.AddUnionMember(memberId, e);
        }
    }
}
