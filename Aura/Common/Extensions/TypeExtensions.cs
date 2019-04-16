using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.Common.Extensions
{
    public static class TypeExtensions
    {
        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            return (T)type.GetCustomAttributes(typeof(T), false).FirstOrDefault();
        }
    }
}
