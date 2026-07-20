using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void Contructor_NullName_Throws()
        {
            var email = new Email("validEmail@Email.com");
            Assert.Throws<BussinessRuleException>(() => new Patient(null!, email));
        }

        [TestMethod]
        public void Contructor_NullEmail_Throws()
        {
            Assert.Throws<BussinessRuleException>(() => new Patient("Name", null!));
        }

        [TestMethod]
        public void Contructor_ValidDentist_NoExceptions()
        {
            var email = new Email("validEmail@Email.com");
            var patient = new Patient("Name", email);
            Assert.AreEqual("Name", patient.Name);
        }
    }
}
