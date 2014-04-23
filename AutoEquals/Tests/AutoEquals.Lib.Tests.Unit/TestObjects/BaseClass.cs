// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseClass.cs" company="AutoEquals">
//   AutoEquals Library. Licence: GNU GPL 2.0. No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   The base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib.Tests.Unit.TestObjects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The base class.
    /// </summary>
    public class BaseClass : AutoEqualsBase
    {
        /// <summary>
        /// Gets or sets the base property.
        /// </summary>
        [EqualsProperty]
        public string StringProperty { get; set; }

        /// <summary>
        /// Gets or sets the property.
        /// </summary>
        [EqualsProperty]
        public int IntProperty { get; set; }

        /// <summary>
        /// Gets or sets the double property.
        /// </summary>
        [EqualsProperty]
        public double DoubleProperty { get; set; }

        /// <summary>
        /// Gets or sets the float property.
        /// </summary>
        [EqualsProperty]
        public float FloatProperty { get; set; }

        /// <summary>
        /// Gets or sets the decimal property.
        /// </summary>
        [EqualsProperty]
        public decimal DecimalProperty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether boolean property.
        /// </summary>
        [EqualsProperty]
        public bool BoolProperty { get; set; }

        /// <summary>
        /// Gets or sets the date time property.
        /// </summary>
        [EqualsProperty]
        public DateTime DateTimeProperty { get; set; }

        /// <summary>
        /// Gets or sets the time span property.
        /// </summary>
        [EqualsProperty]
        public TimeSpan TimeSpanProperty { get; set; }

        /// <summary>
        /// Gets or sets the enumerable property.
        /// </summary>
        [EqualsProperty]
        public IEnumerable<int> EnumerableIntProperty { get; set; }

        /// <summary>
        /// Gets or sets the list property.
        /// </summary>
        [EqualsProperty]
        public List<int> ListIntProperty { get; set; }

        /// <summary>
        /// Gets or sets the collection property.
        /// </summary>
        [EqualsProperty]
        public ICollection<int> CollectionIntProperty { get; set; }

        /// <summary>
        /// Gets or sets the dictionary property.
        /// </summary>
        [EqualsProperty]
        public IDictionary<int, string> DictionaryIntStringProperty { get; set; }
    }
}
