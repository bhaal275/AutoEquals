// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseClassTests.cs" company="AutoEquals">
//   AutoEquals Library. Licence: GNU GPL 2.0. No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the BaseClassTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib.Tests.Unit
{
    using System;
    using System.Collections.Generic;

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
            var baseClass2 = new BaseClass { StringProperty = "Some value" };

            var result = baseClass.Equals(baseClass2);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The equals test different values i enumerable different count return false.
        /// </summary>
        [Test]
        public void EqualsTestDifferentValuesIEnumerableDifferentCountReturnFalse()
        {
            var baseClass = new BaseClass
                                {
                                    BoolProperty = true,
                                    DateTimeProperty = DateTime.MinValue,
                                    DecimalProperty = 1,
                                    DoubleProperty = 2,
                                    FloatProperty = 3,
                                    IntProperty = 4,
                                    StringProperty = "sdome",
                                    TimeSpanProperty = new TimeSpan(1, 2, 3, 4, 5),
                                    EnumerableIntProperty = new List<int> { 1, 2, 3 }
                                };
            var baseClass2 = new BaseClass
            {
                BoolProperty = true,
                DateTimeProperty = DateTime.MinValue,
                DecimalProperty = 1,
                DoubleProperty = 2,
                FloatProperty = 3,
                IntProperty = 4,
                StringProperty = "sdome",
                TimeSpanProperty = new TimeSpan(1, 2, 3, 4, 5),
                EnumerableIntProperty = new List<int> { 1, 2, 3, 4 }
            };

            var result = baseClass.Equals(baseClass2);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The equals test different values i enumerable different elements return false.
        /// </summary>
        [Test]
        public void EqualsTestDifferentValuesIEnumerableDifferentElementsReturnFalse()
        {
            var baseClass = new BaseClass
            {
                BoolProperty = true,
                DateTimeProperty = DateTime.MinValue,
                DecimalProperty = 1,
                DoubleProperty = 2,
                FloatProperty = 3,
                IntProperty = 4,
                StringProperty = "sdome",
                TimeSpanProperty = new TimeSpan(1, 2, 3, 4, 5),
                EnumerableIntProperty = new List<int> { 1, 2, 3 }
            };
            var baseClass2 = new BaseClass
            {
                BoolProperty = true,
                DateTimeProperty = DateTime.MinValue,
                DecimalProperty = 1,
                DoubleProperty = 2,
                FloatProperty = 3,
                IntProperty = 4,
                StringProperty = "sdome",
                TimeSpanProperty = new TimeSpan(1, 2, 3, 4, 5),
                EnumerableIntProperty = new List<int> { 1, 2, 5 }
            };

            var result = baseClass.Equals(baseClass2);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The equals test different values i enumerable same elements returns true.
        /// </summary>
        [Test]
        public void EqualsTestDifferentValuesIEnumerableSameElementsReturnsTrue()
        {
            var baseClass = new BaseClass
            {
                BoolProperty = true,
                DateTimeProperty = DateTime.MinValue,
                DecimalProperty = 1,
                DoubleProperty = 2,
                FloatProperty = 3,
                IntProperty = 4,
                StringProperty = "sdome",
                TimeSpanProperty = new TimeSpan(1, 2, 3, 4, 5),
                EnumerableIntProperty = new List<int> { 1, 2, 3 }
            };
            var baseClass2 = new BaseClass
            {
                BoolProperty = true,
                DateTimeProperty = DateTime.MinValue,
                DecimalProperty = 1,
                DoubleProperty = 2,
                FloatProperty = 3,
                IntProperty = 4,
                StringProperty = "sdome",
                TimeSpanProperty = new TimeSpan(1, 2, 3, 4, 5),
                EnumerableIntProperty = new List<int> { 1, 2, 3 }
            };

            var result = baseClass.Equals(baseClass2);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The equals test same values returns true.
        /// </summary>
        [Test]
        public void EqualsTestSameValuesReturnsTrue()
        {
            var baseClass = new BaseClass { StringProperty = "Some value" };
            var baseClass2 = new BaseClass { StringProperty = "Some value" };

            var result = baseClass.Equals(baseClass2);

            Assert.IsTrue(result);
        }
    }
}
