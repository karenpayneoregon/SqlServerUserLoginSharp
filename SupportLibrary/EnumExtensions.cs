using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportLibrary
{
    public static class EnumExtensions
    {
        public static T EnumParser<T>(string value) => (T)Enum.Parse(typeof(T), value, true);
    }
}
