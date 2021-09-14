using System;
using System.Collections.Generic;
using System.Text;

namespace BabyCarrot.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string s)
        {
            long result;
            return long.TryParse(s, out result);//만약에 성공했을 경우, long형을 어디에 저장할 것인가?
        }

        public static bool IsDateTime(this string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }
            else
            {
                DateTime result;
                return DateTime.TryParse(s,out result);
            }
        }
    }
}
