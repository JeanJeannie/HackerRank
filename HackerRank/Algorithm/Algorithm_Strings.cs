using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithm
{
   public class Algorithm_Strings
   {
      public static void Anagram(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine();

            if (inputString.Length % 2 != 0)
            {
               Console.WriteLine(-1);
               continue;
            }

            var numOfChanges = 0;
            var string1 = inputString.Substring(0, (inputString.Length / 2)); //.ToCharArray().Select(s => s.ToString()).ToList();
            var string2 = inputString.Substring((inputString.Length / 2)); //.ToCharArray().Select(s => s.ToString()).ToList();

            for (int i = 0; i < string2.Length; i++)
            {
               var curPos = string1.IndexOf(string2[i].ToString());
               if (curPos == -1)
               {
                  numOfChanges++;
               }
               else
               {
                  string1 = string1.Remove(curPos, 1);
               }
            }
            Console.WriteLine(numOfChanges);
         }
      }



      public static void GemStones()
      {
         var numOfLines = Convert.ToInt32(Console.ReadLine());
         var elements = Console.ReadLine().ToCharArray().Select(s => s.ToString()).Distinct().ToList();

         for (int lineNo = 1; lineNo < numOfLines; lineNo++)
         {
            var nextLine = Console.ReadLine().ToCharArray();
            elements = elements.Where(w => nextLine.Select(s => s.ToString()).Contains(w)).ToList();
         }
         Console.WriteLine(elements.Count());
      }


      public static void GameOfThrones1()
      {
         var inputString = Console.ReadLine();
         var dict = new Dictionary<string, int>();

         for (int i = 0; i < inputString.Length; i++)
         {
            if (dict.ContainsKey(inputString[i].ToString()))
            {
               dict[inputString[i].ToString()]++;
            }
            else
            {
               dict.Add(inputString[i].ToString(), 1);
            }
         }
         // should all be even except for one
         var oddCount = dict.Where(w => w.Value % 2 != 0).Count();
         if (oddCount > 1)
         {
            Console.WriteLine("NO");
         }
         else
         {
            Console.WriteLine("YES");
         }
      }


      public static void AlternatingCharacters(int numOfTestCases)
      {
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine().ToString().ToCharArray();
            var deletes = 0;
            for (int i = 1; i < inputString.Length; i++)
            {
               if (inputString[i - 1] == inputString[i])
               {
                  deletes++;
               }
            }
            Console.WriteLine(deletes);
         }
      }



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
