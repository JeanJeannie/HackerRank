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
         MaxMin();
//         Console.ReadLine();
      }

      public static void MaxMin()
      {
         var listLength = Convert.ToInt64(Console.ReadLine());
         var subsetLength = Convert.ToInt32(Console.ReadLine());

         var listOfNums = new List<long>();
         for (int listNo = 0; listNo < listLength; listNo++)
         {
            listOfNums.Add(Convert.ToInt64(Console.ReadLine()));
         }

         var sortedList = listOfNums.OrderBy(o => o).ToArray();
         var diffLiff = new List<minMaxNum>();
         for (int i = 0; i < sortedList.Length-subsetLength+1; i++)
         {
            diffLiff.Add(new minMaxNum(sortedList[i], sortedList[i + subsetLength - 1] - sortedList[i]));
         }

         var firstNum = diffLiff.OrderBy(o => o.DiffAhead).First();
         var subsetList = sortedList.Where(w => w >= firstNum.Num).Take(subsetLength).ToList();
         var ans1 = subsetList.Last() - subsetList.First();

         Console.WriteLine(ans1);

      }

      public class minMaxNum {
         public long Num { get; set; }
         public long DiffAhead { get; set; }

         public minMaxNum(long num, long diffAhead)
         {
            Num = num;
            DiffAhead = diffAhead;
         }
      }
   }
}
