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
           LibraryFine();
           Console.ReadLine();
       }

       public static void LibraryFine()
       {
          var actualReturn = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
          var expectedReturn = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();

          var fine = 0;

          // different year


          if (actualReturn[2] > expectedReturn[2])
          {
             fine = 1000;
          }
          else {
             if (actualReturn[1] > expectedReturn[1] && actualReturn[2] == expectedReturn[2])
             {
                fine = (actualReturn[1] - expectedReturn[1]) * 500;
             }
             else
             {
                if (actualReturn[0] > expectedReturn[0] && actualReturn[2] == expectedReturn[2] && actualReturn[1] == expectedReturn[1])
                {
                   fine = (actualReturn[0] - expectedReturn[0]) * 15;
                }
             }
          }
          Console.WriteLine(fine);
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
