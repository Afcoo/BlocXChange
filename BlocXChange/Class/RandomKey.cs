using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlocXChange.Class
{
    public class RandomKey
    {
        public static string GetRandomKey(int Length)
        {
            var Values = new string[] {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                "U", "V", "W", "X", "Y", "Z",
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
            };
            Random r = new Random();

            string Code = string.Empty;

            for(int i = 0; i < Length; i++)
            {
                Code = Code.Insert(Code.Length, Values[r.Next(0, 35)]);
            }

            return Code;
        }
    }
}
