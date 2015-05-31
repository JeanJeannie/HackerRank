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
        
         SherlockAndTheBeast(Convert.ToInt32(Console.ReadLine().ToString()));
      }

      public static void SherlockAndTheBeast(int numOfTests)
      {
         for (int testNo = 0; testNo < numOfTests; testNo++)
         {
            var numOfDigits = Convert.ToInt32(Console.ReadLine());
            var result = GetFivesAndThrees(numOfDigits);
            Console.WriteLine(result.OutputString());
         }
      }

      /**
       * 3 : 555
       * 5 : 33,333
       * 6 : 555,555
       * 7 : -1
       * 8 : 55,533,333  => 8%3=2 => (2+3)%5= 0 1%5 = 0
       * 9 : 555,555,555  => 9%3=0
       * 10 : 3,333,333,333  => 10%3 = 1 => 
       * 
       * 
       * **/

      public static FivesAndThrees GetFivesAndThrees(int numOfDigits)
      {
         var result = new FivesAndThrees(numOfDigits);
         result.Process();
         return result;
      }

      public class FivesAndThrees {
         public int NumOfFives { get; set; }
         public int NumOfThrees { get; set; }
         public int NumOfDigits { get; set; }


         public FivesAndThrees(int numOfDigits)
         {
            NumOfDigits = numOfDigits;
            NumOfFives = 0;
            NumOfThrees = 0;
         }

         public void Process()
         {
            if (NumOfDigits == 3 || NumOfDigits%3 == 0)
            {
               NumOfFives = NumOfDigits;
               return;
            }

            if (NumOfDigits == 5)
            {
               NumOfThrees = NumOfDigits;
               return;
            }

            if (NumOfDigits < 5)
            {
               return;
            }

            var resultFound = false;
            NumOfFives = NumOfDigits;
            NumOfThrees = 0;
            while (!resultFound)
            {
               if (NumOfFives % 3 == 0 && NumOfThrees % 5 == 0)
               {
                  return;
               }

               // take 1 off of the tmpNumFives and retry
               NumOfFives--;
               NumOfThrees++;

               if (NumOfFives == 0) //|| NumOfThrees == 0)
               {
                  if (NumOfThrees > 0 && NumOfDigits % 5 == 0)
                     NumOfThrees = NumOfDigits;
                  else
                     NumOfThrees = 0;
                  return;
               }
            }
         }
         /**
      * 3 : 555
      * 5 : 33,333
      * 6 : 555,555
      * 7 : -1
      * 8 : 55,533,333  => 8%3=2 => (2+3)%5= 0 1%5 = 0
      * 9 : 555,555,555  => 9%3=0
      * 10 : 3,333,333,333  => 10%3 = 1 => 
      * 
      * 
      * **/

         
         public StringBuilder OutputString()
         {
            var builder = new StringBuilder();
            for (int i = 0; i < NumOfFives; i++)
            {
               builder.Append("5");
            }

            for (int i = 0; i < NumOfThrees; i++)
            {
               builder.Append("3");
            }

            if (NumOfThrees == 0 && NumOfFives == 0)
            {
               builder.Append("-1");
            }
            return builder;
         }
      }
   }
}
