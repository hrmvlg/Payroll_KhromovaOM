using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class UnionAffilation : Affiliation
    {
        private Hashtable charges = new Hashtable();
        private int memberId;
        private readonly double charge;

        public UnionAffilation(int memberId, double charge)
        {
            this.memberId = memberId;
            this.charge = charge;
        }

        public UnionAffilation() : this(-1, 0.0) { }

        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return charges[date] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge sc)
        {
            charges[sc.Date] = sc;
        }

        public double Charge { get => charge; }
        public int MemberId { get => memberId; }
    }
}
