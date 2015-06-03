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
         Pangrams();
         //Console.ReadLine();
      }

      public static void Pangrams()
      { 
         var inputString = Console.ReadLine();
         var alphaDict = InitialiseAlphaDict();

         var charString = inputString.ToCharArray();
         for (int i = 0; i < charString.Length; i++)
         {
            var currChar = charString[i].ToString().ToLower();
            if (alphaDict.ContainsKey(currChar)  && !alphaDict[currChar])
            {
               alphaDict[currChar] = true;
            }

            if (!alphaDict.Any(w => w.Value == false))
            {
               Console.WriteLine("pangram");
               return;
            }
         }

         Console.WriteLine("not pangram");
      }

      public static IDictionary<string, bool> InitialiseAlphaDict()
      {
         var retDict = new Dictionary<string, bool>();

         for (char currChar = 'a'; currChar <= 'z'; currChar++)
         {
            retDict.Add(currChar.ToString(), false);
         }

         return retDict;
      }
   }
}
