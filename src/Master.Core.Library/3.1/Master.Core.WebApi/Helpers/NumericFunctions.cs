using System;

namespace Master.Core.WebApi.Helpers
{
    public class NumericFunctions
    {
        public static string Random()
        {
            Random random = new Random();
            return Math.Abs(random.Next()).ToString();
        }

        public static string Random(int multiplier = 10, int maxCharReturn = 3)
        {
            Random random = new Random();
            return Math.Abs(random.Next() * multiplier).ToString().Substring(0, maxCharReturn);
        }
    }
}
