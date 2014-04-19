// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedClassTests.cs" company="AutoEquals">
//   AutoEquals Library. Licence: GNU GPL 2.0. No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the DerivedClassTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib.Tests.Unit
{
    using AutoEquals.Lib.Tests.Unit.TestObjects;

    using NUnit.Framework;

    /// <summary>
    /// The derived class tests.
    /// </summary>
    [TestFixture]
    public class DerivedClassTests
    {
        /// <summary>
        /// The equals test different values returns false.
        /// </summary>
        [Test]
        public void EqualsTestDifferentValuesReturnsFalse()
        {
            var obj1 = new DerivedClass();
            var obj2 = new DerivedClass { DerivedProperty = 1, BaseProperty = "Some value" };

            var result = obj1.Equals(obj2);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The equals test different value returns false.
        /// </summary>
        [Test]
        public void EqualsTestDifferentValueReturnsFalse()
        {
            var obj1 = new DerivedClass { DerivedProperty = 1 };
            var obj2 = new DerivedClass { DerivedProperty = 1, BaseProperty = "Some value" };

            var result = obj1.Equals(obj2);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The equals test same values returns true.
        /// </summary>
        [Test]
        public void EqualsTestSameValuesReturnsTrue()
        {
            var obj1 = new DerivedClass { DerivedProperty = 1, BaseProperty = "Some value" };
            var obj2 = new DerivedClass { DerivedProperty = 1, BaseProperty = "Some value" };

            var result = obj1.Equals(obj2);

            Assert.IsTrue(result);
        }
    }
}
