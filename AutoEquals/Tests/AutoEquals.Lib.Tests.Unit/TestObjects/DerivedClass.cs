// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedClass.cs" company="AutoEquals">
//   AutoEquals Library
//   Licence: GNU GPL 2.0
//   No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the DerivedClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib.Tests.Unit.TestObjects
{
    /// <summary>
    /// The derived class.
    /// </summary>
    public class DerivedClass : BaseClass
    {
        /// <summary>
        /// Gets or sets the derived property.
        /// </summary>
        [EqualsProperty]
        public int DerivedProperty { get; set; }
    }
}
