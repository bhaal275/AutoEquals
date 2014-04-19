using System;
using System.Reflection;

namespace AutoEquals.Lib
{
    public class BaseClass : IEquatable<BaseClass>
    {
        [EqualsProperty]
        public string SomeProp { get; set; }

        public static bool operator ==(BaseClass left, BaseClass right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseClass left, BaseClass right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Overrides the default equality check, and uses the one defined for this base class.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>True if objects are equal based on properties with <see cref="EqualsPropertyAttribute"/> attributes.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return Equals((BaseClass)obj);
        }

        /// <summary>
        /// Performs the equality comparison based on the properties with a <see cref="EqualsPropertyAttribute"/> attribute.
        /// If values of all given properties are equal, then method returns a true value. Otherwise false.
        /// </summary>
        /// <param name="other">Object to compare with.</param>
        /// <returns>If values of all given properties are equal, then method returns a true value. Otherwise false.</returns>
        public bool Equals(BaseClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

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
                        string propType = prop.PropertyType.ToString();

                        var obj1PropValue = EqualityHelpers.GetPropertyValue(this, propName);
                        var obj2PropValue = EqualityHelpers.GetPropertyValue(other, propName);

                        if (!EqualityHelpers.TypeEqual(obj1PropValue, obj2PropValue, propType))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Computes hashcode, by finding all properties with a <see cref="EqualsPropertyAttribute"/> attribute.
        /// Properties can be from either the base class or the derived class.
        /// Hashcode is computed as the sum of hashcodes of properties with a special attribute.
        /// </summary>
        /// <returns>Hashcode computeed from properties with <see cref="EqualsPropertyAttribute"/> attribute.</returns>
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

                            result = (result * 397) ^ (obj1PropValue != null ? obj1PropValue.GetHashCode() : 0);
                        }
                    }
                }

                return result;
            }
        }
    }
}
