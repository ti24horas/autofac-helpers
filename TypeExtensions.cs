namespace Autofac.Helpers
{
    using System;
    using System.Linq;

    public static class TypeExtensions
    {
        public static T GetCustomAttribute<T>(this Type t) where T : Attribute
        {
            var attributes = t.GetCustomAttributes(typeof(T), true).OfType<T>();
            return attributes.FirstOrDefault();
        }
    }
}