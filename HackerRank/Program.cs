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
         PalindromeIndex(Convert.ToInt32(Console.ReadLine()));
        // Console.ReadLine();
      }

      public static void PalindromeIndex(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine();
            Console.WriteLine(IsPalindromic(inputString));

         }
      }

      public static bool FastLook(string inputString, int leftStart, int rightStart, out int? leftEnd, out int? rightEnd)
      {
         leftEnd = null;
         rightEnd = null;
         var left = leftStart;
         var right = rightStart;
         var tmpString = inputString.ToCharArray();

         while (left <= right)
         {
            if (tmpString[left] != tmpString[right])
            {
               leftEnd = left;
               rightEnd = right;
               return false;
            }
            left++;
            right--;
         }
         return true;
      }

      public static int IsPalindromic(string inputString)
      {
         var leftPos = 0;
         var rightPos = inputString.Length-1;
         int? outLeft;
         int? outRight;

         if (!FastLook(inputString, leftPos, rightPos, out outLeft, out outRight))
         {
            leftPos = (int)outLeft;
            rightPos = (int)outRight;
            if (FastLook(inputString, leftPos + 1, rightPos, out outLeft, out outRight))
            {
               return (int)leftPos;
            }

            if (FastLook(inputString, leftPos, rightPos - 1, out outLeft, out outRight))
            {
               return (int)rightPos;
            }
            return 0;
         }
         return -1;
      }
   }
}
