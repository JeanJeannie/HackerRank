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
         TwoStrings(Convert.ToInt32(Console.ReadLine()));
         //         Console.ReadLine();
      }

      public static void TwoStrings(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var firstString = Console.ReadLine().ToCharArray();
            var secondString = Console.ReadLine().ToCharArray();

            bool found = false;
            if (firstString.Intersect(secondString).Any())
               found = true;

            if (found)
               Console.WriteLine("YES");
            else
               Console.WriteLine("NO");

         }
      }

   }
}
