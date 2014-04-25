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
    using System.Diagnostics;

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

        /// <summary>
        /// The measure time.
        /// </summary>
        [Test]
        public void MeasureTime()
        {
            var stopwatch = new Stopwatch();

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
                EnumerableIntProperty = new List<int> { 1, 2, 3 },
                EnumerableGenericProperty = new List<int> { 1, 2, 3, 4 }
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
                EnumerableIntProperty = new List<int> { 1, 2, 3 },
                EnumerableGenericProperty = new List<int> { 1, 2, 3, 4 }
            };

            stopwatch.Start();
            var realEqualsResult = baseClass.RealEquals(baseClass2);
            stopwatch.Stop();

            var realEqualsTime = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            var realHashCode1 = baseClass.RealGetHashCode();
            var realHashCode2 = baseClass2.RealGetHashCode();
            stopwatch.Stop();

            var realGetHashCodeTime = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            var reflectionEqualsResult = baseClass.Equals(baseClass2);
            stopwatch.Stop();

            var reflectionEqualsTime = stopwatch.ElapsedTicks;

            stopwatch.Reset();
            stopwatch.Start();
            var reflectionHashCode1 = baseClass.GetHashCode();
            var reflectionHashCode2 = baseClass2.GetHashCode();
            stopwatch.Stop();

            var reflectionGetHashCodeTime = stopwatch.ElapsedTicks;

            Assert.That(realEqualsTime, Is.GreaterThanOrEqualTo(reflectionEqualsTime));
            Assert.That(realGetHashCodeTime, Is.GreaterThanOrEqualTo(reflectionGetHashCodeTime));

            Assert.AreEqual(realEqualsResult, reflectionEqualsResult);
            Assert.AreEqual(realHashCode1, reflectionHashCode1);
            Assert.AreEqual(realHashCode2, reflectionHashCode2);
            Assert.AreEqual(realHashCode1, realHashCode2);
            Assert.AreEqual(reflectionHashCode1, reflectionHashCode2);
            Assert.AreEqual(realHashCode1, reflectionHashCode2);
            Assert.AreEqual(reflectionHashCode1, realHashCode2);
        }
    }
}
