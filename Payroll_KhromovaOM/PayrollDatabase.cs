using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        } 

        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }

        internal static Employee DeleteEmployee(int id)
        {
            return employees[id] as Employee;
        }
    }
}
