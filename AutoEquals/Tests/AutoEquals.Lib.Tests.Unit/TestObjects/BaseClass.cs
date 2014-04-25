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
    using System.Linq;

    using AutoEquals.Lib.Extensions;

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
        /// The real equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RealEquals(BaseClass other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.StringProperty, other.StringProperty)
                   && this.IntProperty == other.IntProperty && this.DoubleProperty.Equals(other.DoubleProperty)
                   && this.FloatProperty.Equals(other.FloatProperty) && this.DecimalProperty == other.DecimalProperty
                   && this.BoolProperty.Equals(other.BoolProperty)
                   && this.DateTimeProperty.Equals(other.DateTimeProperty)
                   && this.TimeSpanProperty.Equals(other.TimeSpanProperty)
                   && this.EnumerableIntProperty.UnsortedSequencesEqual(other.EnumerableIntProperty);
        }

        /// <summary>
        /// The real get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int RealGetHashCode()
        {
            unchecked
            {
                var hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.StringProperty != null ? this.StringProperty.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.IntProperty;
                hashCode = (hashCode * 397) ^ this.DoubleProperty.GetHashCode();
                hashCode = (hashCode * 397) ^ this.FloatProperty.GetHashCode();
                hashCode = (hashCode * 397) ^ this.DecimalProperty.GetHashCode();
                hashCode = (hashCode * 397) ^ this.BoolProperty.GetHashCode();
                hashCode = (hashCode * 397) ^ this.DateTimeProperty.GetHashCode();
                hashCode = (hashCode * 397) ^ this.TimeSpanProperty.GetHashCode();
                hashCode = (hashCode * 397) ^ (this.EnumerableIntProperty != null ? this.EnumerableIntProperty.Sum(q => q.GetHashCode()) : 0);
                return hashCode;
            }
        }
    }
}
