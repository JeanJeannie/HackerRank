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
         PiSong(Convert.ToInt32(Console.ReadLine()));
         //Console.ReadLine();
      }

      public static void PiSong(int numOfTests)
      {
         int[] pi = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9, 7, 9, 3, 2, 3, 8, 4, 6, 2, 6, 4, 3, 3, 8, 3, 3 };
         for (int testNo = 0; testNo < numOfTests; testNo++)
         {
            var isPi = true;
            var inputLine = Console.ReadLine().Split(' ').ToArray();
            for (int wordNo = 0; wordNo < inputLine.Length; wordNo++)
            {
               if (inputLine[wordNo].Length != pi[wordNo])
               {
                  isPi = false;
                  break;
               }
            }

            if (isPi)
               Console.WriteLine("It's a pi song.");
            else
               Console.WriteLine("It's not a pi song.");

         }
      }
   }
}
