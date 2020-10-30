using System;
using Payroll_KhromovaOM;
using Payroll_KhromovaOM.Commissioned;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll_KhromovaOM.Add;
using Payroll_KhromovaOM.Hourly;

namespace PayrollTest_KhromovaOM
{
    [TestClass]
    public class PayrollTest_KhromovaOM
    {
        [TestMethod]
        public void TestEmployee()
        {
            int empId = 1;
            Employee e = new Employee(empId, "Bob", "Home");
            Assert.AreEqual("Bob", e.Name);
            Assert.AreEqual("Home", e.Address);
            Assert.AreEqual(empId, e.EmpId);
           
        }

        [TestMethod]
        public void TestEmployeeToString()
        {
            int empId = 1;
            Employee e = new Employee(empId, "","");
            Assert.IsNotNull(e.ToString());
        }

        [TestMethod]
        public void TestAddSalariedEmployee()
        {
            int empid = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empid, "Bob", "Home", 1000.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MothlySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);

        }

        [TestMethod]
        public void TestAddCommisionedEmployee()
        {
            int empid = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empid, "Bob", "Home", 1000.00, 0.020);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommisionedClassification);
            CommisionedClassification cc = pc as CommisionedClassification;
            Assert.AreEqual(1000.00, cc.Salary, .001);
            Assert.AreEqual(0.020, cc.CommisionRate);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }


        [TestMethod]
        public void TestAddHourlyEmployee()
        {
            int empid = 1;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bob", "Home", 100.00);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.AreEqual("Bob", e.Name);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(100.00, hc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            AddCommissionedEmployee t = new AddCommissionedEmployee(4, "Bill", "Home", 2500, 3.2);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(4);
            Assert.IsNotNull(e);
            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(4);
            dt.Execute();
            e = PayrollDatabase.GetEmployee(4);
            // ???? nul or not null ????
            Assert.IsNotNull(e);
        }
    }
}
