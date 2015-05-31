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
         SmithNumber(Convert.ToInt32(Console.ReadLine()));

         //Console.ReadLine();
      }

      public static void SmithNumber(int num)
      {
         var primeFactors = PrimeFactors(num);
         var digitSum = DigitSum(num);
         var sumPrimeFactors = SumDigits(primeFactors);

         //Console.WriteLine("prime factors [{0}]", string.Join(" ", primeFactors.ToArray()));
         //Console.WriteLine("digit sum  [{0}]", digitSum);
         //Console.WriteLine("factor sum [{0}]", sumPrimeFactors);

         if (sumPrimeFactors == digitSum)
            Console.WriteLine(1);
         else
            Console.WriteLine(0);
      }

      public static long DigitSum(long num)
      {
         var digits = num.ToString().ToCharArray().Select(s => Convert.ToInt64(s.ToString())).ToList(); //.Sum(s => Convert.ToInt32(s));
         return SumDigits(digits);
      }

      public static long SumDigits(List<long> primeFactors)
      {
         long ret = 0;
         foreach (var factor in primeFactors)
         {
            ret = ret + factor.ToString().ToCharArray().Select(s => Convert.ToInt64(s.ToString())).Sum();

         }
         return ret;
      }

      public static List<long> PrimeFactors(long num)
      {
         var primeFactorList = new List<long>();
         while (num % 2 == 0)
         {
            primeFactorList.Add(2);
            num = num / 2;
         }

         for (long i = 3; i < Math.Ceiling(Math.Sqrt(num)); i++)
         {
            while (num % i == 0)
            {
               primeFactorList.Add(i);
               num = num / i;
            }
         }

         if (num > 2)
            primeFactorList.Add(num);

         return primeFactorList;
      }
   }
}
