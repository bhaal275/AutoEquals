// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseClassTests.cs" company="AutoEquals">
//   AutoEquals Library
//   Licence: GNU GPL 2.0
//   No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the BaseClassTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib.Tests.Unit
{
    using AutoEquals.Lib.Tests.Unit.TestObjects;

    using NUnit.Framework;

    /// <summary>
    /// The base class tests.
    /// </summary>
    [TestFixture]
    public class BaseClassTests
    {
        /// <summary>
        /// The equals test different values returns false.
        /// </summary>
        [Test]
        public void EqualsTestDifferentValuesReturnsFalse()
        {
            var baseClass = new BaseClass();
            var baseClass2 = new BaseClass { BaseProperty = "Some value" };

            var result = baseClass.Equals(baseClass2);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The equals test same values returns true.
        /// </summary>
        [Test]
        public void EqualsTestSameValuesReturnsTrue()
        {
            var baseClass = new BaseClass { BaseProperty = "Some value" };
            var baseClass2 = new BaseClass { BaseProperty = "Some value" };

            var result = baseClass.Equals(baseClass2);

            Assert.IsTrue(result);
        }
    }
}
