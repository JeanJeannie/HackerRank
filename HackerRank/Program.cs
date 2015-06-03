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
         MakeItAnAnagram();
         //         Console.ReadLine();
      }

      public static void MakeItAnAnagram()
      {
         var numOfChanges = 0;
         var string1 = Console.ReadLine();
         var string2 = Console.ReadLine();

         numOfChanges = numOfChanges + MakeAnagram(string2, string1);
         numOfChanges = numOfChanges + MakeAnagram(string1, string2);


         Console.WriteLine(numOfChanges);

      }

      public static int MakeAnagram(string stringToAnagram, string stringToChange)
      {
         var numOfChanges = 0;
         for (int i = 0; i < stringToAnagram.Length; i++)
         {
            var curPos = stringToChange.IndexOf(stringToAnagram[i].ToString());
            if (curPos == -1)
            {
               numOfChanges++;
            }
            else
            {
               stringToChange = stringToChange.Remove(curPos, 1);
            }
         }
         return numOfChanges;
      }

   }
}
