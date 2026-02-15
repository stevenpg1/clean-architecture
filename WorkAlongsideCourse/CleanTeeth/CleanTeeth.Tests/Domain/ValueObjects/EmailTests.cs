using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))] // this attribute need to be removed if using mstest4
        public void Constructor_NullEmail_Throws()
        {
            new Email(null!);

            //this is the mstest4 new syntax, we are using version 3 lkfnslfk
            //var ex = Assert.ThrowsExactly<BusinessRuleException>(() => new Email(null!));
            //Assert.AreEqual($"The Email is required", ex);
        }

        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_EmailWithoutAt_Throws()
        {
            //new Email("felipe.com");
        }

        [TestMethod]
        public void Constructor_ValidEmail_NoExceptions()
        {
            new Email("felipe@example.com");
        }
    }
}
