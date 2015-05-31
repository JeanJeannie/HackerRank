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
            TimeInWords();            
      }

      public static void TimeInWords()
      {
         var hour = Convert.ToInt32(Console.ReadLine());
         var minute = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine(TimeString(hour, minute));
      }

         public static string TimeString(int hour, int min)
         {
            var pastTo = "past";
            if (min > 30)
            {
               pastTo = "to";
               min = 60 - min;
               hour = (hour + 1) % 12;
            }

            var textHour = "";
            if (hour >= 10)
               textHour = teensDigit(hour);
            else
               textHour = singleDigit(hour);


            if (min == 0)
            {
               return string.Format("{0} {1}", textHour, "o' clock");
            }

            if (min < 10)
            {
               return string.Format("{0} minute{1} {2} {3}", singleDigit(min), min == 1 ? "" : "s", pastTo, textHour);
            }

            if (min == 15)
            {
               return string.Format("quarter {0} {1}", pastTo, textHour);            
            }

            if (min == 30)
            {
               return string.Format("half {0} {1}", pastTo, textHour);
            }

            if (min < 20)
            {
               return string.Format("{0} minute{1} {2} {3}", teensDigit(min), min == 1 ? "" : "s", pastTo, textHour);
            }

            // must be 21 - 29;
            return string.Format("twenty {0} minute{1} {2} {3}", singleDigit(min.ToString().ToCharArray().Select(s => Convert.ToInt32(s.ToString())).ToList().Last()), min == 1 ? "" : "s", pastTo, textHour);
         }

         public static string singleDigit(int num)
         {
            switch (num)
            {
               case 1:
                  return "one";
               case 2:
                  return "two";
               case 3:
                  return "three";
               case 4:
                  return "four";
               case 5:
                  return "five";
               case 6:
                  return "six";
               case 7:
                  return "seven";
               case 8:
                  return "eight";
               case 9:
                  return "nine";
               default:
                  break;
            }
            return null;
         }

         public static string tensDigit(int num)
         {
            switch (num)
            {
               case 1:
                  return "ten";
               case 2:
                  return "twenty";
               case 3:
                  return "thirty";
               default:
                  break;
            }
            return null;
         }

         public static string teensDigit(int num)
         {
            switch (num)
            {
               case 10:
                  return "ten";
               case 11:
                  return "eleven";
               case 12:
                  return "twelve";
               case 13:
                  return "thirteen";
               case 14:
                  return "fourteen";
               case 15:
                  return "fifteen";
               case 16:
                  return "sixteen";
               case 17:
                  return "seventeen";
               case 18:
                  return "eighteen";
               case 19:
                  return "nineteen";
               default:
                  break;
            }
            return null;
         }
   }
}
