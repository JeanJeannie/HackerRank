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
         IsFibo(Convert.ToInt32(Console.ReadLine()));            
//         Console.ReadLine();
      }

      public static void IsFibo(int numTestCases)
      {
         for (int i = 0; i < numTestCases; i++)
         {
            var num = Convert.ToInt64(Console.ReadLine());
            if (IsFibonacciNumber(num))
               Console.WriteLine("IsFibo");
            else
               Console.WriteLine("IsNotFibo");
         }
      }

      public static bool IsFibonacciNumber(long num)
      {
         long currNum = 1;
         long lastNum = 0;
         long fiboNum = currNum + lastNum;

         if (num == currNum || num == lastNum)
            return true;

         while (fiboNum <= num)
         {
            fiboNum = currNum + lastNum;
            lastNum = currNum;
            currNum = fiboNum;

            if (num == fiboNum)
               return true;
         }
         return false;        
      }
   }
}
