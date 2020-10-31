using System;
using Payroll_KhromovaOM;
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

        [TestMethod]
        public void TimeCardTransaction()
        {
            int empid = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home", 15.25);
            t.Execute();
            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2015, 10, 31), 8.0, empid);
            tct.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            TimeCard tc = hc.GetTimeCard(new DateTime(2015, 10, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }

        [TestMethod]
        public void SalesReceiptTransaction()
        {
            int empid = 1;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empid, "Bill", "Home", 15.25, 12.2);
            t.Execute();
            SalesReceiptTransaction srt = new SalesReceiptTransaction(new DateTime(2015, 10, 31), 8, empid);
            srt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommisionedClassification);
            CommisionedClassification cc = pc as CommisionedClassification;
            SalesReceipt sr = cc.GetSalesReceipt(new DateTime(2015, 10, 31));
            Assert.IsNotNull(sr);
            Assert.AreEqual(8, sr.Amound);
        }

        [TestMethod]
        public void AddServiceCharge()
        {
            int empid = 7;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home", 15.25);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            UnionAffilation af = new UnionAffilation();
            e.Affiliation = af;
            int memberId = 86;
            PayrollDatabase.AddUnionMember(memberId, e);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(
                memberId, new DateTime(2015, 11, 8), 12.95);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge(new DateTime(2015, 11, 8));
            Assert.IsNotNull(sc);
            //Assert.AreEqual(12.15, sc.Charge, .001);
        }

        [TestMethod]
        public void TestChangeNameTransaciton()
        {
            int empid = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home", 15.25);
            t.Execute();
            ChangeNameTransaction cnt = new ChangeNameTransaction(empid, "Bob");
            cnt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        [TestMethod]
        public void TestChangeAddressTransaciton()
        {
            int empid = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home", 15.25);
            t.Execute();
            ChangeAddressTransaction cat = new ChangeAddressTransaction(empid, "Another home");
            cat.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            Assert.AreEqual("Another home", e.Address);
        }

        [TestMethod]
        public void ChangeHourlyTransaction()
        {
            int empid = 8;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empid, "Lance", "Home", 2500, 3.2);
            t.Execute();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empid, 27.52);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [TestMethod]
        public void ChangeSalariedTransaction()
        {
            int empid = 8;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empid, "Lance", "Home", 2500, 3.2);
            t.Execute();
            ChangeSalariedTransaction cht = new ChangeSalariedTransaction(empid, 2500);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(2500, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MothlySchedule);
        }

        [TestMethod]
        public void ChangeCommissionedTransaction()
        {
            int empid = 8;
            AddSalariedEmployee t = new AddSalariedEmployee(empid, "Lance", "Home", 2500);
            t.Execute();
            ChangeCommissionedTransaction cht = new ChangeCommissionedTransaction(empid, 2500, 0.020);
            cht.Execute();
            Employee e = PayrollDatabase.GetEmployee(empid);
            Assert.IsNotNull(e);
            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommisionedClassification);
            CommisionedClassification cc = pc as CommisionedClassification;
            Assert.AreEqual(2500.00, cc.Salary, .001);
            Assert.AreEqual(0.020, cc.CommisionRate);
            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }

        [TestMethod]
        public void TestChangeUnionMember()
        {
            int empid = 12;
            AddHourlyEmployee t = new AddHourlyEmployee(empid, "Bill", "Home", 15.35);
            t.Execute();
            int memberid = 7743;
            ChangeMemberTransaction cmt = new ChangeMemberTransaction(empid, memberid, 99.42);
            Employee e = PayrollDatabase.GetEmployee(empid);
            cmt.Execute();
            Assert.IsNotNull(e);
            Affiliation affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffilation);
            UnionAffilation uf = affiliation as UnionAffilation;
            Assert.AreEqual(99.42, uf.Charge, .001);
            Employee member = PayrollDatabase.GetUnionMember(memberid);
            Assert.IsNotNull(member);
            Assert.AreEqual(e, member);
        }
    }
}
