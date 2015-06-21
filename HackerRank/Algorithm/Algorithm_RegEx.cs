﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HackerRank.Algorithm
{
   public class Algorithm_RegEx
   {
      public static void HackerRankTweets(int numOfTestCases)
      {
         var reg = new Regex(@".*[Hh][Aa][Cc][Kk][Ee][Rr][Rr][Aa][Nn][Kk].*");
         var tweetCount = 0;
         for (int testCase = 0; testCase < numOfTestCases; testCase++)
         {
            var inputString = Console.ReadLine();
            if (reg.IsMatch(inputString))
            {
               tweetCount++;
            }
         }
         Console.WriteLine(tweetCount);
      }


      public static void PANNumber(int numOfTestCases)
      {
         var regEx = new Regex(@"[A-Z]{5}\d{4}[A-Z]{1}");
         for (int testCase = 0; testCase < numOfTestCases; testCase++)
         {
            var inputString = Console.ReadLine();
            if (regEx.IsMatch(inputString))
            {
               Console.WriteLine("YES");
            }
            else
            {
               Console.WriteLine("NO");
            }
         }
      }

   }
}