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
         //Socks(Convert.ToInt32(Console.ReadLine()));
           Console.ReadLine();
      }

      public static void MakeItAnAnagram()
      {
         var numOfChanges = 0;
         var string1 = Console.ReadLine(); 
         var string2 = Console.ReadLine(); 

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
