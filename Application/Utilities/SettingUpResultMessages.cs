using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Application.Utilities
{
    public static class SettingUpResultMessages
    {
        public static string EnumToString(Enum myEnum)
        {
            int index = 0;
            string result = "";
            try
            {
                var myEnumType = myEnum.GetType();
                var names = myEnumType.GetFields()
                    .Where(m => m.GetCustomAttribute<DisplayAttribute>() != null)
                    .Select(e => e.GetCustomAttribute<DisplayAttribute>().Name);
                var values = Enum.GetValues(myEnumType);
                foreach (var value in values)
                {
                    if (value.ToString() == myEnum.ToString())
                    {
                        index = (int)value;
                        break;
                    }
                }
                result = names.ElementAt(index - 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return result;
        }
    }
}
