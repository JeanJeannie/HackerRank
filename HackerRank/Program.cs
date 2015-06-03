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
         AlternatingCharacters(Convert.ToInt32(Console.ReadLine()));
         //Console.ReadLine();
      }

      public static void AlternatingCharacters(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine().ToString().ToCharArray();
            var deletes = 0;
            for (int i = 1; i < inputString.Length; i++)
            {
               if (inputString[i - 1] == inputString[i])
               {
                  deletes++;
               }
            }
            Console.WriteLine(deletes);
         }
      }

   }
}
