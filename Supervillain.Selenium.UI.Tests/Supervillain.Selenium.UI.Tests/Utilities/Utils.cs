using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Utilities
{
    public class Utils
    {
        private static Random random = new Random();

        public static string RandomStrinGenerator(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
