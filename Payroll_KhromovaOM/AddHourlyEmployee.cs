﻿using Payroll_KhromovaOM.Hourly;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM.Add
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private readonly double hourlyRate;

        public AddHourlyEmployee(int empid, string name, string address, double hourlyRate) 
            : base(empid, name, address)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClassification(hourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }
    }
}
