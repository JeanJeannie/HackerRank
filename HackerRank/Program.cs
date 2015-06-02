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
          FunnyString(Convert.ToInt32(Console.ReadLine()));
          //Console.ReadLine();
      }

       public static void FunnyString(int numOfTestCases)
       {
           for (int i = 0; i < numOfTestCases; i++)
           {
               var inputString = Console.ReadLine().ToCharArray();

               var strLen = inputString.Length;
               var isFunny = true;
               for (int j = 0; j < Math.Ceiling((double)inputString.Length/2); j++)
               {
                   if (strLen == 1)
                   {
                       break;
                   }

                   var diffLeft = Math.Abs(inputString[j + 1] - inputString[j]);
                   var diffRight = Math.Abs(inputString[strLen - (j + 1)] - inputString[strLen - (j + 2)]);
                   if (diffLeft != diffRight)
                   {
                       isFunny = false;
                       break;
                   }
               }

               if (isFunny)
               {
                   Console.WriteLine("Funny");
               }
               else
               {
                   Console.WriteLine("Not Funny");
               }
           }
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
