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
         Anagram(Convert.ToInt32(Console.ReadLine()));
       //  Console.ReadLine();
      }

      public static void Anagram(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine();

            if (inputString.Length % 2 != 0)
            {
               Console.WriteLine(-1);
               continue;
            }

            var numOfChanges = 0;
            var string1 = inputString.Substring(0, (inputString.Length / 2)); //.ToCharArray().Select(s => s.ToString()).ToList();
            var string2 = inputString.Substring((inputString.Length / 2)); //.ToCharArray().Select(s => s.ToString()).ToList();

            for (int i = 0; i < string2.Length; i++)
            {
               var curPos = string1.IndexOf(string2[i].ToString());
               if (curPos == -1)
               {
                  numOfChanges++;
               }
               else
               {
                  string1 = string1.Remove(curPos, 1);
               }
            }
            Console.WriteLine(numOfChanges);
         }
      }

   }
}
