﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Payroll_KhromovaOM
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();
        private static Hashtable unionMembers = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        } 
        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }

        public static Employee DeleteEmployee(int id)
        {
            return employees[id] as Employee;
        }

        public static void AddUnionMember(int memberId, Employee e)
        {
            unionMembers[memberId] = e;
        }
        public static Employee GetUnionMember(int memberId)
        {
           return unionMembers[memberId] as Employee;
        }
        public static void RemoveUnionMember(int memberId)
        {
            unionMembers.Remove(memberId);
        }
    }
}
