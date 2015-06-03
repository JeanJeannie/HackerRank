using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithm
{
   public class Algorithm_Strings
   {
      public static void Pangrams()
      {
         var inputString = Console.ReadLine();
         var alphaDict = InitialiseAlphaDict();

         var charString = inputString.ToCharArray();
         for (int i = 0; i < charString.Length; i++)
         {
            var currChar = charString[i].ToString().ToLower();
            if (alphaDict.ContainsKey(currChar) && !alphaDict[currChar])
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

      public static void FunnyString(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var inputString = Console.ReadLine().ToCharArray();

            var strLen = inputString.Length;
            var isFunny = true;
            for (int j = 0; j < Math.Ceiling((double)inputString.Length / 2); j++)
            {
               if (strLen == 1)
               {
                  break;
               }

               var diffLeft = Math.Abs(inputString[j + 1] - inputString[j]);
               var diffRight = Math.Abs(inputString[strLen - (j + 1)] - inputString[strLen - (j + 2)]);
               if (diffLeft != diffRight)
               {
                  isFunny = false;
                  break;
               }
            }

            if (isFunny)
            {
               Console.WriteLine("Funny");
            }
            else
            {
               Console.WriteLine("Not Funny");
            }
         }
      }


   }
}
