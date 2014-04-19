// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualityHelpers.cs" company="AutoEquals">
//   AutoEquals Library
//   Licence: GNU GPL 2.0
//   No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the EqualityHelpers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib
{
    /// <summary>
    /// The equality helpers.
    /// </summary>
    public static class EqualityHelpers
    {
        /// <summary>
        /// The get property value.
        /// </summary>
        /// <param name="obj">
        /// The object to get a property from.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// Value of a given property in a given object.
        /// </returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        /// <summary>
        /// Performs the equality check between the two objects.
        /// </summary>
        /// <param name="obj1">First object to check.</param>
        /// <param name="obj2">Second object to compare with.</param>
        /// <param name="typeName">String definition of the full namespace type defining the type of both objects.</param>
        /// <returns>True if objects are equal, using a check most suitable for a given type.</returns>
        public static bool TypeEqual(object obj1, object obj2, string typeName)
        {
            if (typeName == "System.String")
            {
                return string.Equals(obj1, obj2);
            }

            // ReSharper disable once RedundantNameQualifier
            return object.Equals(obj1, obj2);
        }
    }
}
