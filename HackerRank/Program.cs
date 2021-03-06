﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using HackerRank.AlgorithmWarmUpEasy;

using System.Text;
using System.Text.RegularExpressions;

namespace HackerRank
{

   public class Solution
   {
      static void Main(String[] args)
      {
         /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
         // AmericanEnglish(Convert.ToInt32(Console.ReadLine()));
         Console.ReadLine();
      }



      public static void FlippingBits()
      {
         var numTest = Convert.ToInt32(Console.ReadLine());
         for (int i = 0; i < numTest; i++)
         {
            var tempNum = Convert.ToUInt32(Console.ReadLine());
            var maxNum = Convert.ToUInt32(Math.Pow(2, 32) - 1);
            var retNum = tempNum ^ maxNum;
            Console.WriteLine(retNum);
         }
      }

      public static void CommonChild()
      {
         var firstString = Console.ReadLine().ToCharArray();
         var secondString = Console.ReadLine();

         int childLen = 0;

         for (int charPos = 0; charPos < firstString.Length; charPos++)
         {
            var pos = secondString.IndexOf(firstString[charPos]);
            if (pos > 0)
            {
               childLen++;
               secondString.Remove(pos, 1);
            }
         }
         Console.WriteLine(childLen);
      }

      public static void ModifiedFibonacci()
      {
         var inputLine = Console.ReadLine().Split(' ').ToArray();
         var firstTerm = inputLine[0];
         var secondTerm = inputLine[1];
         var termToFind = Convert.ToInt32(inputLine[2]);

         decimal term1;
         decimal term2;

         decimal.TryParse(firstTerm, out term1);
         decimal.TryParse(secondTerm, out term2);

         for (int i = 2; i < termToFind; i++)
         {
            var tempTerm = Fibo(term1, term2);
            term1 = term2;
            term2 = tempTerm;
         }
         Console.WriteLine(string.Format("{0:0}", term2));
      }

      public static decimal Fibo(decimal term1, decimal term2)
      {
         return (term2 * term2) + term1;
      }




      public static void MorganAndAString(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var firstString = Console.ReadLine().ToCharArray();
            var secondString = Console.ReadLine().ToCharArray();
            var answer = new StringBuilder(); new List<char>();


            var firstPos = 0;
            var secondPos = 0;

            var stop = false;

            while (!stop)
            {
               if (firstString[firstPos] == secondString[secondPos])
               {
                  // need to scan down until we find the string with the lowest first non matching char
                  var tmpFirst = firstPos;
                  var tmpSecond = secondPos;
                  while (firstString[tmpFirst] == secondString[secondPos])
                  {
                     tmpFirst++;
                     tmpSecond++;

                     if (tmpFirst == firstString.Length || tmpSecond == secondString.Length)
                     {
                        break;
                     }
                  }

                  if (firstString[tmpFirst] < secondString[tmpSecond])
                  {
                     answer.Append(firstString[firstPos]);
                     firstPos++;
                  }
                  else
                  {
                     answer.Append(secondString[secondPos]);
                     secondPos++;
                  }
               }
               else
               {
                  if (firstString[firstPos] <= secondString[secondPos])
                  {
                     answer.Append(firstString[firstPos]);
                     firstPos++;
                  }
                  else
                  {
                     if (secondString[secondPos] < firstString[firstPos])
                     {
                        answer.Append(secondString[secondPos]);
                        secondPos++;
                     }
                  }
               }
               if (firstPos >= firstString.Length)
               {
                  for (int i = secondPos; i < secondString.Length; i++)
                  {
                     answer.Append(secondString[i]);
                  }
                  stop = true;
                  break;
               }

               if (secondPos >= secondString.Length)
               {
                  for (int j = firstPos; j < firstString.Length; j++)
                  {
                     answer.Append(firstString[j]);
                  }
                  stop = true;
                  break;
               }
            }
            Console.WriteLine(answer);
         }
      }
   }
}
