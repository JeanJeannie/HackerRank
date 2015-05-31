﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.AlgorithmWarmUpEasy
{
   public class WarmUpEasy
   {
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


      public static void PiSong(int numOfTests)
      {
         int[] pi = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9, 7, 9, 3, 2, 3, 8, 4, 6, 2, 6, 4, 3, 3, 8, 3, 3 };
         for (int testNo = 0; testNo < numOfTests; testNo++)
         {
            var isPi = true;
            var inputLine = Console.ReadLine().Split(' ').ToArray();
            for (int wordNo = 0; wordNo < inputLine.Length; wordNo++)
            {
               if (inputLine[wordNo].Length != pi[wordNo])
               {
                  isPi = false;
                  break;
               }
            }

            if (isPi)
               Console.WriteLine("It's a pi song.");
            else
               Console.WriteLine("It's not a pi song.");

         }
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
         for (int i = 0; i < sortedList.Length - subsetLength + 1; i++)
         {
            diffLiff.Add(new minMaxNum(sortedList[i], sortedList[i + subsetLength - 1] - sortedList[i]));
         }

         var firstNum = diffLiff.OrderBy(o => o.DiffAhead).First();
         var subsetList = sortedList.Where(w => w >= firstNum.Num).Take(subsetLength).ToList();
         var ans1 = subsetList.Last() - subsetList.First();

         Console.WriteLine(ans1);

      }

      public class minMaxNum
      {
         public long Num { get; set; }
         public long DiffAhead { get; set; }

         public minMaxNum(long num, long diffAhead)
         {
            Num = num;
            DiffAhead = diffAhead;
         }
      }


        public static void FillingJars()
      {
         var tmpInput = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
         var numOfJars = tmpInput[0];
         var numOfOperations = tmpInput[1];

         long totalSum = 0;
         for (int opNum = 0; opNum < numOfOperations; opNum++)
         {
            tmpInput = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
            var totalThisOp = (tmpInput[1] - tmpInput[0] + 1) * tmpInput[2];
            totalSum = totalSum + totalThisOp;
         }
         var average = Math.Floor((decimal)totalSum / (decimal)numOfJars);
         Console.WriteLine(average);
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

      public class FivesAndThrees
      {
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
            if (NumOfDigits == 3 || NumOfDigits % 3 == 0)
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

      public class gcdDigit
      {
         public long Digit { get; set; }
         public List<long> _factors = null;

         public gcdDigit(string digit)
         {
            Digit = Convert.ToInt64(digit);
         }

         public List<long> Factors
         {
            get
            {
               if (_factors != null)
                  return _factors;

               _factors = GetFactors(Digit).Where(w => w > 1).Distinct().ToList();
               return _factors;
            }
         }

         public override string ToString()
         {
            return string.Format("[{0}]({1})", Digit, string.Join(",", Factors.Select(s => s).ToArray()));
         }

         public static IEnumerable<long> GetFactors(long x)
         {
            long max = (long)Math.Ceiling(Math.Sqrt(x));
            for (long factor = 1; factor <= max; factor++)
            {
               if (x % factor == 0)
               {
                  yield return factor;
                  if (factor != max)
                     yield return x / factor;
               }
            }
         }
      }

      public class gcdSubSet
      {
         public List<gcdDigit> subSet { get; set; }
         public gcdSubSet()
         {
            subSet = new List<gcdDigit>();
         }

         public bool hasCommonFactors()
         {
            // go through the subset and check if any of them have common factors.
            var currDigit = subSet[0];
            var commonFactors = currDigit.Factors;
            var subSetExcludingCurrDigit = subSet.Where(w => w.Digit != currDigit.Digit).ToList();
            for (int i = 0; i < subSetExcludingCurrDigit.Count(); i++)
            {
               // go through the other factors and decrease the matching list
               commonFactors = commonFactors.Where(w => subSetExcludingCurrDigit[i].Factors.Contains(w)).ToList();
               if (!commonFactors.Any())
               {
                  //Console.WriteLine("subset not matching " + ToString());
                  return false;
               }
            }

            return true;
         }

         public bool hasDuplicates()
         {
            return subSet.GroupBy(x => x.Digit).Any(g => g.Count() > 1);
         }

         public override string ToString()
         {
            string stringToReturn = null;
            foreach (var item in subSet)
            {
               if (stringToReturn == null)
                  stringToReturn = item.ToString();
               else
                  stringToReturn = stringToReturn + " " + item.ToString();
            }
            return stringToReturn;
         }

      }

      public static IEnumerable<char[]> BinaryGrid(int numOfElements)
      {
         var largestBinaryNum = (long)Math.Pow(2, Convert.ToDouble(numOfElements));
         for (long i = 1; i <= largestBinaryNum; i++)
         {
            var binaryString = Convert.ToString(i, 2).PadLeft(numOfElements, '0');
            yield return binaryString.ToCharArray();
         }
      }


      public static IEnumerable<gcdSubSet> GetSubsets(gcdDigit[] arrayOfDigits)
      {
         foreach (var value in BinaryGrid(arrayOfDigits.Count()))
         {
            gcdSubSet combo = new gcdSubSet();
            for (int currCombo = 0; currCombo < arrayOfDigits.Count(); currCombo++)
            {
               if (value[currCombo] == '1')
               {
                  combo.subSet.Add(arrayOfDigits[currCombo]);
               }
            }
            yield return combo;
         }
      }

      static int FindGCD(int m, int n)
      {
         int r = m % n;

         while (r != 0)
         { // Euclid's Algorithm (Greatest Common Divisor)
            m = n;
            n = r;
            r = m % n;
         }
         return n;
      }

      public static void SherlockAndTheGcd(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var digitCount = Convert.ToInt32(Console.ReadLine());
            var arrayOfNums = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
            var sortedArrayOfNums = arrayOfNums.OrderBy(o => o).ToArray();

            var subsetExists = SubSetExists(digitCount, sortedArrayOfNums);

            if (subsetExists)
            {
               Console.WriteLine("YES");
            }
            else
            {
               Console.WriteLine("NO");
            }

         }
         //    Console.ReadLine();
      }

      public static bool SubSetExists(int digitCount, int[] arrayOfNums)
      {
         if (arrayOfNums.Any(a => a == 1))  // if there's a 1 in the array then return true;
         {
            return true;
         }

         var gcdArray = new Dictionary<List<int>, int>();

         // need to store the GCD(a, b) and then run through the rest
         for (int j = 0; j < digitCount; j++)
         {
            gcdArray.Add(new List<int> { arrayOfNums[j] }, arrayOfNums[j]);// load the array with the single GCDs
         }

         for (int complexity = 2; complexity < digitCount; complexity++)
         {
            var tmpArray = new Dictionary<List<int>, int>();
            var keyLookup = new List<string>();
            // only want to look at the keys which have the same number of ints as the complexity
            foreach (var item in gcdArray)
            {
               foreach (var currDigit in arrayOfNums)
               {
                  if (!item.Key.Contains(currDigit))
                  {
                     var tmpKey = item.Key.Select(s => s).ToList();
                     tmpKey.Add(currDigit);

                     var tmpStringKey = string.Join(" ", tmpKey.OrderBy(o => o).Select(s => s.ToString()).ToArray());
                     if (!keyLookup.Any(s => s == tmpStringKey))
                     {
                        var gcd = FindGCD(item.Value, currDigit);

                        if (gcd == 1)  // as soon as we find a subset that doesn't have any GCD then break;
                        {
                           return true;
                        }

                        tmpArray.Add(tmpKey, gcd);
                        keyLookup.Add(tmpStringKey);
                     }
                  }
               }
            }

            gcdArray = tmpArray;
         }

         return false;
      }



      public static void TaumAndBday(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var arrayOfGifts = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
            var arrayOfCosts = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();

            var B = arrayOfGifts[0]; // num of Black gifts
            var W = arrayOfGifts[1]; // num of White gifts
            var X = arrayOfCosts[0]; // cost of Black gifts
            var Y = arrayOfCosts[1]; // cost of White gifts
            var Z = arrayOfCosts[2]; // cost of converting gifts 

            long costOfGifts = (X * B) + (Y * W);
            long tmpCost = 0;
            if (Z < Math.Abs(X - Y))  // if the conversion is less than the diff between the prices
            {
               if (X <= Y)
               {
                  // if black gifts are cheaper than buy the whole lot and then convert to the white gift number
                  tmpCost = (X * (B + W)) + (W * Z);
               }
               else
               {
                  tmpCost = (Y * (B + W)) + (B * Z);
               }
               if (tmpCost < costOfGifts)
               {
                  costOfGifts = tmpCost;
               }
            }
            Console.WriteLine(costOfGifts);
         }
      }


      public static void AcmIcpcTeam()
      {
         var inputLine1 = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
         var numOfPeople = inputLine1[0];
         var numOfTopics = inputLine1[1];
         var peopleTopics = new string[numOfPeople];
         for (int i = 0; i < numOfPeople; i++)
         {
            var binTopics = Console.ReadLine();
            peopleTopics[i] = binTopics;  // store the topics as strings as integers not large enough.. 
         }
         var topicsKnown = new char[numOfTopics];

         // run through the teams and work out what the max num of totals is.
         // problem here as 11110 == 01111 will give the same number of topics but potentially different numbers so need to store both

         var maxTopicsKnown = 0;
         var topicsKnownList = new Dictionary<Tuple<int, int>, Tuple<string, char[], int>>(); // team(a, b) = topicsKnownAsInt, topicsKnownAsBinary, topicCount
         for (int i = 0; i < numOfPeople; i++)
         {
            for (int j = i + 1; j < numOfPeople; j++)
            {
               var team = new Tuple<int, int>(i, j);
               var person1 = peopleTopics[i].ToCharArray();
               var person2 = peopleTopics[j].ToCharArray();
               for (int k = 0; k < numOfTopics; k++)
               {
                  if (person1[k] == '1' || person2[k] == '1')
                  {
                     topicsKnown[k] = '1';
                  }
                  else
                  {
                     topicsKnown[k] = '0';
                  }
               }
               var teamTopics = new Tuple<string, char[], int>(topicsKnown.ToString(), topicsKnown, topicsKnown.Count(w => w == '1'));
               topicsKnownList.Add(team, teamTopics); // list of teams and the topics they know

               if (teamTopics.Item3 >= maxTopicsKnown)
               {
                  maxTopicsKnown = teamTopics.Item3;
               }
            }
         }

         var smartTeams = 0;
         // we've found the max count now lets find the ones that have the same count
         foreach (var team in topicsKnownList)
         {
            if (team.Value.Item3 == maxTopicsKnown)
               smartTeams++;
         }

         Console.WriteLine(maxTopicsKnown);
         Console.WriteLine(smartTeams);
      }

      public static void manasaAndStones(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var numOfStones = Convert.ToInt32(Console.ReadLine());
            var diffA = Convert.ToInt32(Console.ReadLine());
            var diffB = Convert.ToInt32(Console.ReadLine());

            if (diffB < diffA) // if the 2nd number is smaller then swap their positions
            {
               var tempInt = diffA;
               diffA = diffB;
               diffB = tempInt;
            }
            var lastStones = new List<int>();

            if (diffA == diffB)
            {
               var numToWrite = diffA * (numOfStones - 1);
               Console.Write(numToWrite);
               Console.WriteLine();
               continue;
            }
            for (int j = 0; j < numOfStones; j++)
            {
               var numToWrite = diffB * j + diffA * (numOfStones - j - 1);
               if (!lastStones.Contains(numToWrite))
                  lastStones.Add(numToWrite);
            }

            bool firstTime = true;
            foreach (var lastStone in lastStones)
            {
               if (!firstTime)
               {
                  Console.Write(' ');
               }
               else
               {
                  firstTime = false;
               }
               Console.Write(lastStone);
            }
            Console.WriteLine();
         }
      }

      public static void halloweenParty(int numberOfTestCases)
      {
         for (int i = 0; i < numberOfTestCases; i++)
         {
            var numOfCuts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Math.Ceiling((double)numOfCuts / 2) * Math.Floor((double)numOfCuts / 2));
         }
      }

      public static void theAngryProfessor(int numberOfTestCases)
      {
         for (int i = 0; i < numberOfTestCases; i++)
         {
            var inputLine1 = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
            var numOfStudents = inputLine1[0];
            var minStudentsForClass = inputLine1[1];

            var arrivalTimes = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
            if (arrivalTimes.Where(w => w <= 0).Count() >= minStudentsForClass)
            {
               Console.WriteLine("NO");
            }
            else
            {
               Console.WriteLine("YES");
            }
         }
      }

      public static void cutTheSticks(int numberOfSticks)
      {
         var arrayOfStickLengths = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
         var tempArray = arrayOfStickLengths;
         while (tempArray.Count() > 0)
         {
            var cutLength = tempArray.Min();
            Console.WriteLine(tempArray.Count());
            tempArray = tempArray.Select(s => s - cutLength).Where(w => w > 0).ToArray();
         }
      }

      public static void lonelyInteger(int numberOfIntegers)
      {
         var arrayOfNumbers = Console.ReadLine().Split(' ');
         var dictOfNumbers = new Dictionary<int, int>();

         for (int i = 0; i < numberOfIntegers; i++)
         {
            var currNumber = Convert.ToInt32(arrayOfNumbers[i]);
            if (dictOfNumbers.ContainsKey(currNumber))
            {
               dictOfNumbers[currNumber]++;
            }
            else
            {
               dictOfNumbers.Add(currNumber, 1);
            }
         }
         Console.WriteLine(dictOfNumbers.Where(w => w.Value == 1).First().Key);

      }

      public static void loveLetterMystery(int testCaseNumber)
      {
         for (int i = 0; i < testCaseNumber; i++)
         {
            var inputString = Console.ReadLine();
            var origWord = inputString.ToCharArray();
            int opCount = 0;
            int lPos = 0;
            int rPos = origWord.Length - lPos - 1;
            for (int j = 0; j < Math.Ceiling((double)(origWord.Length / 2)); j++)
            {
               if (origWord[lPos] > origWord[rPos])
               {
                  opCount = opCount + (origWord[lPos] - origWord[rPos]);
                  origWord[lPos] = origWord[rPos];
               }
               else
               {
                  opCount = opCount + (origWord[rPos] - origWord[lPos]);
                  origWord[rPos] = origWord[lPos];
               }
               lPos++; // look at the next character
               rPos = origWord.Length - lPos - 1;
            }
            Console.WriteLine(opCount);
         }
      }


      // given the freewayLength and the number of test cases, read in each test case (consisting of enterIndex and exitIndex of service array (inputLine2)) return the min width
      public static void serviceLanes(string[] inputLine1, string[] inputLine2)
      {
         //         int freewayLength = Convert.ToInt32(inputLine1[0]);
         int testCases = Convert.ToInt32(inputLine1[1]);
         //const int bikeOnly = 1;
         //const int carOnly = 2;
         //const int bikeAndCar = 3;

         for (int i = 0; i < testCases; i++)
         {
            var inputTestCase = Console.ReadLine().Split(' ');
            var entryIndex = Convert.ToInt32(inputTestCase[0]);
            var exitIndex = Convert.ToInt32(inputTestCase[1]);

            int? minWidth = null;
            for (int j = entryIndex; j <= exitIndex; j++)
            {
               if (minWidth == null || Convert.ToInt32(inputLine2[j]) < minWidth)
               {
                  minWidth = Convert.ToInt32(inputLine2[j]);
               }
            }
            Console.WriteLine(minWidth);
         }

      }


      // find the max Xor of all the pairing of numbers between left & right vals
      public static int maximisingXor(int leftVal, int rightVal)
      {
         int retVal = 0;

         for (int i = leftVal; i <= rightVal; i++)
         {
            for (int j = leftVal; j <= rightVal; j++)
            {
               var tempVal = i ^ j;
               if (tempVal > retVal)
               {
                  retVal = tempVal;
               }
            }

         }

         return retVal;
      }

      // given the number of cycles, read in the test cycles - for each odd number of cycles (spring) double the height, for even (summer) add 1 metre
      public static void utopianTree(int noOfTests, int initialHeight = 1)
      {

         for (int i = 0; i < noOfTests; i++)
         {
            int noOfCycles = Convert.ToInt32(Console.ReadLine());
            int retValue = initialHeight;
            for (int j = 1; j <= noOfCycles; j++)
            {
               if (j % 2 == 0) // must be even
               {
                  retValue++;
                  continue;
               }
               // spring
               retValue = retValue * 2;

            }
            Console.WriteLine(retValue);
         }
      }



      // given the number of lines to read, return the sum of the 2 integers provided on each of those lines
      public static void solveMeSecond(int linesToRead)
      {
         for (int i = 0; i < linesToRead; i++)
         {
            string txt2 = Console.ReadLine();
            var txtArray = txt2.Split(' ');
            Console.WriteLine(Convert.ToInt32(txtArray[0]) + Convert.ToInt32(txtArray[1]));
         }

      }

      // return sum of two integers
      public static int solveMeFirst(int val1, int val2)
      {
         return val1 + val2;
      }


   }
}
