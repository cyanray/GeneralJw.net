using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Encrypt
{
    internal class Param
    {
        private const string Key = "yt6n78";
        private const string charTable = "0123456789abcdefghijklmnopqrstuvwxyz";

        public static string GetString(Dictionary<string, string> qParams)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;
            foreach (var item in qParams)
            {
                if (i++ != 0)
                {
                    result.Append("&");
                }
                result.Append(item.Key).Append("=").Append(item.Value);
            }
            return result.ToString();
        }

        public static string Encrypt(string str, string key = Key)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(key)) return str;
            int length1 = str.Length;
            int length2 = key.Length;
            int ceil = (int)Math.Ceiling((1.0d * length1) / ((double)length2));
            int ceil2 = ((int)Math.Ceiling(length1 * 3.0d * 6.0d / 9.0d / 6.0d)) * 6 % length2;
            string str4 = string.Empty;
            for (int i2 = 0; i2 < ceil; i2++)
            {
                for (int i3 = 1; i3 <= length2; i3++)
                {
                    int i4 = (i2 * length2) + i3;
                    string substring = str.Substring(i4 - 1, 1);
                    string substring2 = key.Substring(i3 - 1, 1);
                    string str5 = "000" + (substring[0] + substring2[0] + ceil2).ToString();
                    str4 = str4 + str5.Substring(str5.Length - 3);
                    if (i4 == length1)
                    {
                        break;
                    }
                }
            }
            var result = new StringBuilder();
            int i = 0;
            while (i < str4.Length)
            {
                int i5 = i + 9;
                int len = Math.Min(str4.Length, i5) - i;
                string substring3 = str4.Substring(i, len);
                string val = DecTo36(Convert.ToInt64(substring3));
                string str6 = $"000000{val}";
                result.Append(str6.Substring(str6.Length - 6));
                i = i5;
            }
            return result.ToString();
        }

        private static string DecTo36(long j)
        {
            if (j < 0)
            {
                return "-" + DecTo36(Math.Abs(j));
            }
            var result = new StringBuilder();
            do
            {
                string ch = charTable[(int)(j % 36)].ToString();
                result.Insert(0, ch);
                j /= 36;
            } while (j > 0);
            return result.ToString();
        }

    }
}
