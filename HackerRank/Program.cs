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
         GemStones();
         //Console.ReadLine();
      }

      public static void GemStones()
      {
            var numOfLines = Convert.ToInt32(Console.ReadLine());
            var elements = Console.ReadLine().ToCharArray().Select(s => s.ToString()).Distinct().ToList();

            for (int lineNo = 1; lineNo < numOfLines; lineNo++)
            {
               var nextLine = Console.ReadLine().ToCharArray();
               elements = elements.Where(w => nextLine.Select(s => s.ToString()).Contains(w)).ToList();
            }
            Console.WriteLine(elements.Count());
         }
   }
}
