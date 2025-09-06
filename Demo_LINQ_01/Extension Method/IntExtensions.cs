using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LINQ_01.Extension_Method
{
    internal static class IntExtensions
    {
        public static int Reverse(this int Number)
        {
            int ReversedNumber = 0, Reminder;
            while (Number != 0)
            {
                Reminder = Number % 10;
                ReversedNumber = ReversedNumber * 10 + Reminder;
                Number = Number / 10;
            }
            return ReversedNumber;
        }
    }

}
