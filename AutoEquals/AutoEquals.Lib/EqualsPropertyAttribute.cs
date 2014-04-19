using System;

namespace AutoEquals.Lib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class EqualsPropertyAttribute : Attribute
    {
    }
}
