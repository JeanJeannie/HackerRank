using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using HackerRank.AlgorithmWarmUpEasy;

using System.Text;

namespace HackerRank
{

   class Solution
   {
       static void Main(String[] args)
       {
           /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
           TimeConversion();
           Console.ReadLine();
       }

       public static void TimeConversion()
       {
           var amPmTime = Console.ReadLine().Split(':').ToArray();
           var pm = false;

           var hour = Convert.ToInt32(amPmTime[0]);
           var min = Convert.ToInt32(amPmTime[1]);
           var secPart = amPmTime[2].ToCharArray();
           var sec = Convert.ToInt32(amPmTime[2].Substring(0, 2));
           if (secPart[2].ToString().ToUpper() == "P")
           {
               if (hour != 12)
               {
                   hour = (hour + 12) % 24;                   
               }
           }
           else
           {
               if (hour == 12)
                   hour = 0;
           }
           Console.WriteLine("{0:00}:{1:00}:{2:00}", hour, min, sec );
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
           return (term2*term2) + term1;
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
