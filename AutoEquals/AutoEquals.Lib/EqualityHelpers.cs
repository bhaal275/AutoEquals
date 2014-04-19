namespace AutoEquals.Lib
{
    public static class EqualityHelpers
    {
        public static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        public static bool TypeEqual(object obj1, object obj2, string typeName)
        {
            if (typeName == "System.String")
            {
                return StringsEqual(obj1, obj2);
            }

            return Equals(obj1, obj2);
        }

        private static bool StringsEqual(object obj1, object obj2)
        {
            return string.Equals(obj1, obj2);
        }
    }
}
