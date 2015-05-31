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
         FillingJars();
      }

      public static void FillingJars()
      {
         var tmpInput = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
         var numOfJars = tmpInput[0];
         var numOfOperations = tmpInput[1];

         long totalSum = 0;
         for (int opNum = 0; opNum < numOfOperations; opNum++)
         {
            tmpInput = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
            var totalThisOp = (tmpInput[1] - tmpInput[0] + 1) * tmpInput[2];
            totalSum = totalSum + totalThisOp;
         }
         var average = Math.Floor((decimal)totalSum / (decimal)numOfJars);
         Console.WriteLine(average);
      }
   }
}
