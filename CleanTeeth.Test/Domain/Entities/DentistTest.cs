using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        public void Contructor_NullName_Throws()
        {
            var email = new Email("validEmail@Email.com");
            Assert.Throws<BussinessRuleException>(() => new Dentist(null!, email));
        }
        
        [TestMethod]
        public void Contructor_NullEmail_Throws()
        {
            Assert.Throws<BussinessRuleException>(() => new Dentist("Name", null!));
        }
        
        [TestMethod]
        public void Contructor_ValidDentist_NoExceptions()
        {
            var email = new Email("validEmail@Email.com");
            var dentist = new Dentist("Name", email);
            Assert.AreEqual("Name", dentist.Name );
        }
    }
}
