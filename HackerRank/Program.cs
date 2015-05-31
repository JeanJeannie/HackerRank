using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using HackerRank.AlgorithmWarmUpEasy;

using System.Text;

namespace HackerRank
{

   class Solution
   {
      static void Main(string[] args)
      {
         ModifiedKaprekarNumbers();            
      }

      public static void ModifiedKaprekarNumbers()
      {
         var lowestNumber = Convert.ToInt32(Console.ReadLine());
         var highestNumber = Convert.ToInt32(Console.ReadLine());

         var listKaprekar = new List<int>();
         for (int i = lowestNumber; i <= highestNumber; i++)
         {
            if (KaprekarNumber(i))
               listKaprekar.Add(i);
         }
         if (listKaprekar.Any())
            Console.WriteLine(string.Join(" ", listKaprekar.ToArray()));
         else
            Console.WriteLine("INVALID RANGE");
      }

      public static bool KaprekarNumber(int num)
      {
         var sqrNum = Math.Pow(num, 2);
         var textSqrNum = sqrNum.ToString(); //.ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToArray();

         var leftBit = textSqrNum.Substring(0, (int)Math.Floor((double)textSqrNum.Length / 2));
         var rightBit = textSqrNum.Substring((int)Math.Floor((double)textSqrNum.Length / 2));

    //     Console.WriteLine("sqr [{0}] left [{1}] right [{2}]", textSqrNum, leftBit, rightBit);
         if (Convert.ToInt32(rightBit) + (leftBit == ""? 0 : Convert.ToInt32(leftBit)) == num)
            return true;
         return false;
      }

   }
}
