// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsPropertyAttribute.cs" company="AutoEquals">
//   AutoEquals Library
//   Licence: GNU GPL 2.0
//   No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Defines the EqualsPropertyAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib
{
    using System;

    /// <summary>
    /// The equals property attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EqualsPropertyAttribute : Attribute
    {
    }
}
