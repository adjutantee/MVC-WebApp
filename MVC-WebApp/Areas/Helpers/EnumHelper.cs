using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MVC_WebApp.Helpers
{
    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
