using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTemplate.Helper
{
    internal static class StringHelper
    {
        internal static String ConvertBytesToString(byte[] inputString)
        {
            if (inputString == null)
                return "";

            var retString = Encoding.UTF8.GetString(inputString);
            for (int i = 0; i < retString.Length; i++)
            {
                string t = retString.Substring(i, 1);
                if (t == "\0")
                {
                    retString = retString.Substring(0, i);
                    return retString;
                }
            }

            return retString;
        }
    }
}
