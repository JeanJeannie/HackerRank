using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HackerRank.Algorithm
{
   public class Algorithm_RegEx
   {

      public static void AmericanEnglish(int numOfTestCases)
      {
         var inputStrings = new List<string>();
         for (int testCase = 0; testCase < numOfTestCases; testCase++)
         {
            inputStrings.Add(Console.ReadLine());
         }

         var wordNum = Convert.ToInt32(Console.ReadLine());
         for (int currentWord = 0; currentWord < wordNum; currentWord++)
         {
            var foundCount = 0;
            var wordToFind = Console.ReadLine();
            var regExText = string.Format(@"\b({0}|{1})\b", wordToFind, wordToFind.Replace("ze", "se"));
            foreach (var inputStr in inputStrings)
            {
               foundCount = foundCount + Regex.Matches(inputStr, regExText).Count;
            }
            Console.WriteLine(foundCount);
         }
      }

      public static void HackerRankLanguage(int numOfTestCases)
      {
         // 5 digits, space, and then word (\b means word boundary so space before/after etc) from the list
         var regEx = new Regex(@"^\d{5}\s\b(C|CPP|JAVA|PYTHON|PERL|PHP|RUBY|CSHARP|HASKELL|CLOJURE|BASH|SCALA|ERLANG|CLISP|LUA|BRAINFUCK|JAVASCRIPT|GO|D|OCAML|R|PASCAL|SBCL|DART|GROOVY|OBJECTIVEC)\b$");
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine();
            if (regEx.IsMatch(inputString))
            {
               Console.WriteLine("VALID");
            }
            else
            {
               Console.WriteLine("INVALID");
            }
         }
      }

      public static void SayingHi(int numOfTestCases)
      {
         var regEx = new Regex(@"\A[Hh][Ii]\s[^dD].+");
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine();
            if (regEx.IsMatch(inputString))
            {
               Console.WriteLine(inputString);
            }
         }
      }

      public static void UtopianIdentificationNumber(int numOfTestCases)
      {
         var regEx = new Regex(@"^[a-z]{0,3}\d{2,8}[A-Z]{3,}$");
         for (int testNo = 0; testNo < numOfTestCases; testNo++)
         {
            var inputString = Console.ReadLine();
            if (regEx.IsMatch(inputString))
            {
               Console.WriteLine("VALID");
            }
            else
            {
               Console.WriteLine("INVALID");
            }
         }
      }


      public static void FraudPrevention(int numOfRecords)
      {
         var records = new List<GroupOnRecord>();
         for (int recordNum = 0; recordNum < numOfRecords; recordNum++)
         {
            records.Add(new GroupOnRecord(Console.ReadLine()));
         }

         var fraudRecords = new List<long>();
         var recArray = records.ToArray();
         for (int i = 0; i < recArray.Length - 1; i++)
         {
            var currRecord = recArray[i];
            //if (fraudRecords.Contains(currRecord.DealId))
            // continue;

            for (int j = i + 1; j < recArray.Length; j++)
            {
               if (GroupOnRecord.Fraudulent(currRecord, recArray[j]))
               {
                  if (!fraudRecords.Contains(currRecord.OrderId))
                     fraudRecords.Add(currRecord.OrderId);

                  if (!fraudRecords.Contains(recArray[j].OrderId))
                     fraudRecords.Add(recArray[j].OrderId);
               }
            }
         }

         Console.WriteLine(string.Join(",", fraudRecords.OrderBy(s => s).ToArray()));
      }

      public class GroupOnRecord
      {
         public long OrderId { get; set; }
         public long DealId { get; set; }
         public string EmailAddress { get; set; }
         public string StreetAddress { get; set; }
         public string City { get; set; }
         public string State { get; set; }
         public string ZipCode { get; set; }
         public string CreditCard { get; set; }

         public GroupOnRecord(string record)
         {
            var tempArray = record.Split(',').ToArray();

            OrderId = Convert.ToInt64(tempArray[0]);

            DealId = Convert.ToInt64(tempArray[1]);

            var tempEmail = tempArray[2].ToLower().Split('@');
            var frontEmailPart = tempEmail[0].Replace(".", string.Empty);
            frontEmailPart = frontEmailPart.Split('+')[0];
            EmailAddress = string.Format("{0}@{1}", frontEmailPart, tempEmail[1]);

            StreetAddress = tempArray[3].ToLower().Replace("st.", "street").Replace("rd.", "road");

            City = tempArray[4].ToLower();

            State = tempArray[5].ToLower();
            switch (State)
            {
               case "il":
                  State = "illinois";
                  break;
               case "ca":
                  State = "california";
                  break;
               case "ny":
                  State = "new york";
                  break;
               default:
                  break;
            }

            ZipCode = tempArray[6].Replace("-", string.Empty);

            CreditCard = tempArray[7];
         }

         public static bool Fraudulent(GroupOnRecord recordOne, GroupOnRecord recordTwo)
         {
            if (recordOne.DealId == recordTwo.DealId
               && recordOne.EmailAddress == recordTwo.EmailAddress
               && recordOne.CreditCard != recordTwo.CreditCard)
               return true;

            if (recordOne.DealId == recordTwo.DealId
               && recordOne.StreetAddress == recordTwo.StreetAddress
               && recordOne.City == recordTwo.City
               && recordOne.State == recordTwo.State
               && recordOne.ZipCode == recordTwo.ZipCode
               && recordOne.CreditCard != recordTwo.CreditCard)
               return true;

            return false;
         }
      }



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
