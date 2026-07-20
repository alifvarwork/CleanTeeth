using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Test.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTest
    {
        [TestMethod]
        public void Contructor_NullName_Throws()
        {
            Assert.Throws<BussinessRuleException>(() => new DentalOffice(null!));
        }
    }
}
