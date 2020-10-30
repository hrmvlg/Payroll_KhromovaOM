using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class ServiceChargeTransaction : Transaction
    {
        private readonly int memberId;
        private readonly DateTime time;
        private readonly double charge;

        public ServiceChargeTransaction(int memberId, DateTime time, double charge)
        {
            this.memberId = memberId;
            this.time = time;
            this.charge = charge;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetUnionMember(memberId);
            if (e != null)
            {
                UnionAffilation ua = null;
                if (e.Affiliation is UnionAffilation)
                    ua = e.Affiliation as UnionAffilation;
                if (ua != null)
                    ua.AddServiceCharge(new ServiceCharge(time, charge));
                else
                    throw new InvalidOperationException(
                        "Попытка добавить плату за услуги для члена" +
                        "профсоюза с незарегестрированным членством");
            }
            else
                throw new InvalidOperationException("Член профсоюза не наден");
        }
    }
}

