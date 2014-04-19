using NUnit.Framework;

namespace AutoEquals.Lib.Tests.Unit
{
    [TestFixture]
    public class DerivedClassTests
    {
        [Test]
        public void EqualsTestDifferentValuesReturnsFalse()
        {
            var obj1 = new DerivedClass();
            var obj2 = new DerivedClass { SecondProperty = 1, SomeProp = "Some value" };

            var result = obj1.Equals(obj2);

            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsTestDifferentValueReturnsFalse()
        {
            var obj1 = new DerivedClass { SecondProperty = 1 };
            var obj2 = new DerivedClass { SecondProperty = 1, SomeProp = "Some value" };

            var result = obj1.Equals(obj2);

            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsTestSameValuesReturnsTrue()
        {
            var obj1 = new DerivedClass { SecondProperty = 1, SomeProp = "Some value" };
            var obj2 = new DerivedClass { SecondProperty = 1, SomeProp = "Some value" };

            var result = obj1.Equals(obj2);

            Assert.IsTrue(result);
        }
    }
}
