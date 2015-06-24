using System;
using System.Text.RegularExpressions;

namespace HackerRank.Algorithm
{
   public class Algorithm_RegEx
   {
      public static void FindHackerRank(int numOfTestCases)
      {
         var regEntire = new Regex(@"^hackerrank$");
         var regEnd = new Regex(@"^.+hackerrank$");
         var regStart = new Regex(@"^hackerrank.+$");

         for (int testNum = 0; testNum < numOfTestCases; testNum++)
         {
            var inputString = Console.ReadLine();
            if (regEntire.IsMatch(inputString))
            {
               Console.WriteLine(0);
               continue;
            }

            if (regStart.IsMatch(inputString))
            {
               Console.WriteLine(1);
               continue;
            }

            if (regEnd.IsMatch(inputString))
            {
               Console.WriteLine(2);
               continue;
            }

            Console.WriteLine(-1);

         }
      }


      public static void SplitThePhoneNumber(int numOfTestCases)
      {
         var regEx = new Regex(@"^(\d{1,3})[\-\s]{1}(\d{1,3})[\-\s]{1}(\d{4,10})$");
         for (int testCase = 0; testCase < numOfTestCases; testCase++)
         {
            var inputString = Console.ReadLine();
            var regExMatch = regEx.Match(inputString);
            Console.WriteLine("CountryCode={0},LocalAreaCode={1},Number={2}", regExMatch.Groups[1], regExMatch.Groups[2], regExMatch.Groups[3]);
         }

      }
      
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
