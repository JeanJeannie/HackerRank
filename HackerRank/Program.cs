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
         GameOfThrones1();
         //Console.ReadLine();
      }

      public static void GameOfThrones1()
      {
         var inputString = Console.ReadLine();
         var dict = new Dictionary<string, int>();

         for (int i = 0; i < inputString.Length; i++)
			{
			   if (dict.ContainsKey(inputString[i].ToString()))
            {
               dict[inputString[i].ToString()]++;
            }
            else
            {
               dict.Add(inputString[i].ToString(), 1);
            }
			}
         // should all be even except for one
         var oddCount = dict.Where(w => w.Value%2 != 0).Count();
         if (oddCount > 1)
         {
            Console.WriteLine("NO");
         }
         else
         {
            Console.WriteLine("YES");
         }
      }
   }
}
