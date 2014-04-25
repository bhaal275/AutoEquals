// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoEqualsBase.cs" company="AutoEquals">
//   AutoEquals Library. Licence: GNU GPL 2.0. No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the AutoEqualsBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The base class defining the Equals and GetHashCode methods.
    /// </summary>
    public abstract class AutoEqualsBase : IEquatable<AutoEqualsBase>
    {
        /// <summary>
        /// The equality operator, which uses the overridden equals method.
        /// </summary>
        /// <param name="left">
        /// The left operand.
        /// </param>
        /// <param name="right">
        /// The right operand.
        /// </param>
        /// <returns>
        /// True if objects are equal based on the properties with <see cref="EqualsPropertyAttribute"/> attributes.
        /// </returns>
        public static bool operator ==(AutoEqualsBase left, AutoEqualsBase right)
        {
            // ReSharper disable once RedundantNameQualifier
            return object.Equals(left, right);
        }

        /// <summary>
        /// The inequality operator, which uses the overridden equals method.
        /// </summary>
        /// <param name="left">
        /// The left operand.
        /// </param>
        /// <param name="right">
        /// The right operand.
        /// </param>
        /// <returns>
        /// True if objects are NOT equal based on the properties with <see cref="EqualsPropertyAttribute"/> attributes.
        /// </returns>
        public static bool operator !=(AutoEqualsBase left, AutoEqualsBase right)
        {
            // ReSharper disable once RedundantNameQualifier
            return !object.Equals(left, right);
        }

        /// <summary>
        /// Overrides the default equality check, and uses the one defined for this base class.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>True if objects are equal based on properties with <see cref="EqualsPropertyAttribute"/> attributes.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.Equals((AutoEqualsBase)obj);
        }

        /// <summary>
        /// Performs the equality comparison based on the properties with a <see cref="EqualsPropertyAttribute"/> attribute.
        /// If values of all given properties are equal, then method returns a true value. Otherwise false.
        /// </summary>
        /// <param name="other">Object to compare with.</param>
        /// <returns>If values of all given properties are equal, then method returns a true value. Otherwise false.</returns>
        public bool Equals(AutoEqualsBase other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var type = GetType();

            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    var equalsAttr = attr as EqualsPropertyAttribute;
                    if (equalsAttr != null)
                    {
                        string propName = prop.Name;

                        var obj1PropValue = EqualityHelpers.GetPropertyValue(this, propName);
                        var obj2PropValue = EqualityHelpers.GetPropertyValue(other, propName);

                        if (!EqualityHelpers.TypeEqual(obj1PropValue, obj2PropValue, prop.PropertyType))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Computes hash code, by finding all properties with a <see cref="EqualsPropertyAttribute"/> attribute.
        /// Properties can be from either the base class or the derived class.
        /// Hash code is computed as the sum of hash codes of properties with a special attribute.
        /// </summary>
        /// <returns>Hash code computed from properties with <see cref="EqualsPropertyAttribute"/> attribute.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                var type = GetType();

                PropertyInfo[] props = type.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        var equalsAttr = attr as EqualsPropertyAttribute;
                        if (equalsAttr != null)
                        {
                            string propName = prop.Name;

                            var obj1PropValue = EqualityHelpers.GetPropertyValue(this, propName);
                            var propertyType = prop.PropertyType;

                            result = (result * 397) ^ EqualityHelpers.TypeHashCode(obj1PropValue, propertyType);
                        }
                    }
                }

                return result;
            }
        }
    }
}
