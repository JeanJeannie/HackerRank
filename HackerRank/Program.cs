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
         BiggerIsGreater(Convert.ToInt32(Console.ReadLine()));
       //          Console.ReadLine();
      }

      public static void BiggerIsGreater(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine(); //.ToCharArray();
            var outputString = "no answer";
            var stop = false;
            for (int i = inputString.ToCharArray().Length-2; i >= 0 ; i--)
            {
               var subset = inputString.Substring(i).ToCharArray();
               var currChar = inputString[i]; // start with last 2 currs
               for (int j = 1; j < subset.Length; j++)  // cur char should be at pos 0 so skip it
               {
                  if (currChar < subset[j])
                  {
                     // we need to find the next greatest char
                     var nextGreatestChar = subset.Where(w => w > currChar).OrderBy(o => o).First();
                     var pos = (new string(subset)).IndexOf(nextGreatestChar);
                     var decreasedSubset = (new string(subset)).Remove(pos, 1).ToCharArray().OrderBy(o => o).ToArray();
                     var left = inputString.Substring(0, i);
                     var right = new string(decreasedSubset);
                     outputString = left + nextGreatestChar.ToString() + right;
                     stop = true;
                     break;
                  }
               }

               if (stop)
                  break;                              
            }

            Console.WriteLine(outputString);
            
         }
      }
   }
}
