using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoEquals.Lib.Tests.Unit
{
    [TestFixture]
    public class BaseClassTests
    {
        [Test]
        public void EqualsTestDifferentValuesReturnsFalse()
        {
            var baseClass = new BaseClass();
            var baseClass2 = new BaseClass {SomeProp = "Some value"};

            var result = baseClass.Equals(baseClass2);

            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsTestSameValuesReturnsTrue()
        {
            var baseClass = new BaseClass { SomeProp = "Some value" };
            var baseClass2 = new BaseClass { SomeProp = "Some value" };

            var result = baseClass.Equals(baseClass2);

            Assert.IsTrue(result);
        }
    }
}
