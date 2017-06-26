using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApiSeed.AxHelpers
{
    public class StringHelpers
    {
        public static string GenerateRandomString(int length)
        {
            var stringBuilder = new StringBuilder(length);
            var chArray = "abcdefghijklmnopqrstuvwxyz0123456789_-".ToCharArray();
            var random = new Random((int)DateTime.Now.Ticks);
            for (var index = 0; index < length; ++index)
                stringBuilder.Append(chArray[random.Next(chArray.Length)]);
            return stringBuilder.ToString().ToLower();
        }
        public static string GenerateRandomNumber(int length)
        {
            var stringBuilder = new StringBuilder(length);
            var chArray = "0123456789".ToCharArray();
            var random = new Random((int)DateTime.Now.Ticks);
            for (var index = 0; index < length; ++index)
                stringBuilder.Append(chArray[random.Next(chArray.Length)]);
            return stringBuilder.ToString();
        }
    }
}