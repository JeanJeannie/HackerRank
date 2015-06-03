using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithm
{
   class Algorithm_Combinatorics
   {
      public static void Socks(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var pairsOfSocks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(pairsOfSocks + 1);
         }
      }

   }
}
