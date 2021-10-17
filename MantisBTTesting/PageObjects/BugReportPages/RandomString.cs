using System;
using System.Text;

namespace MantisBTTesting
{
    static class RandomString
    {
        static public string Create(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return (Convert.ToString(str_build));
        }
    }
}
