using Payroll_KhromovaOM.Hourly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class TimeCardTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empid;

        public TimeCardTransaction(DateTime date,   double hours, int empid)
        {
            this.date = date;
            this.hours = hours;
            this.empid = empid;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empid);
            if (e != null)
            {
                HourlyClassification hc = e.Classification as HourlyClassification;
                if (hc != null)
                {
                    hc.AddTimeCard(new TimeCard(date, hours));
                }
                else
                    throw new InvalidOperationException("Попытка добавления карточки табельного учета" +
                        " для работника с почасовой оплатой");
            }
            else
                throw new InvalidOperationException("Работник не найден");
        }
    }
}
