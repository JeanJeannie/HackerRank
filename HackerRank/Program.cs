using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using HackerRank.AlgorithmWarmUpEasy;

using System.Text;
using System.Text.RegularExpressions;

namespace HackerRank
{

   public class Solution
   {
       static void Main(String[] args)
       {
           /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
          MatrixRotation();
         // Console.ReadLine();
       }

       public static void MatrixRotation()
       {
          var firstInput = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
          var row = firstInput[0];
          var col = firstInput[1];
          var rotationNum = firstInput[2];
          var totalRotation = (2 * col) + (2 * row) - 4;
          rotationNum = rotationNum % totalRotation;
          var numOfBoxes = col <= row ? col / 2 : row / 2;

          var origMatrix = GetGrid(row, col);
          var tempMatrix = origMatrix;
          for (int i = 0; i < rotationNum; i++)
          {
             tempMatrix = RotateMatrixOnce(tempMatrix, row, col, numOfBoxes, i == rotationNum-1);
          }
       }

       public static bool IsInLeftCol(int row, int col, int totalRows, int totalCols, int numOfBoxes)
       {
          if (col < numOfBoxes 
             && row >= col 
             && row < (totalRows-col))
             return true;

          return false;
       }

       public static bool IsInRightCol(int row, int col, int totalRows, int totalCols, int numOfBoxes)
       {
          if (col >= (totalCols - numOfBoxes) // right col
             && row >= (totalCols - 1 - col)  // but needs to be between this row
             && row < totalRows-(totalCols - 1 - col))  // and this row
             return true;

          return false;
       }

       public static bool IsInTopRow(int row, int col, int totalRows, int totalCols, int numOfBoxes)
       {
          if (row < numOfBoxes // top row
             && col >= row  // but between these columns 
             && col < totalCols - row)
             return true;

          return false;
       }

       public static bool IsInBottomRow(int row, int col, int totalRows, int totalCols, int numOfBoxes)
       {
          if (row >= (totalRows-numOfBoxes) 
             && col >= (totalRows-1-row)  // but between these columns 
             && col < totalCols-(totalRows -1-row))
             return true;

          return false;
       }


       public static string[,] RotateMatrixOnce(string[,] origMatrix, int numOfRows, int numOfCols, int numOfBoxes, bool lastRotation = false)
       {
          var retMatrix = new string[numOfRows, numOfCols];
          for (int i = 0; i < numOfRows; i++)
          {
             for (int j = 0; j < numOfCols; j++)
             {
                var isLeft = IsInLeftCol(i, j, numOfRows, numOfCols, numOfBoxes);
                var isTop = IsInTopRow(i, j, numOfRows, numOfCols, numOfBoxes);
                if (isLeft && !isTop)
                {
                   retMatrix[i, j] = origMatrix[i - 1, j];  // one above
                   if (lastRotation)
                   {
                      Console.Write(retMatrix[i, j]);
                      if (j == numOfCols - 1)
                         Console.WriteLine();
                      else
                         Console.Write(' ');
                   }
                   continue;
                }
                var isRight = IsInRightCol(i, j, numOfRows, numOfCols, numOfBoxes);
                if (isTop && !isRight)
                {
                   retMatrix[i, j] = origMatrix[i, j + 1];
                   if (lastRotation)
                   {
                      Console.Write(retMatrix[i, j]);
                      if (j == numOfCols - 1)
                         Console.WriteLine();
                      else
                         Console.Write(' ');
                   }
                   continue;
                }
                var isBottom = IsInBottomRow(i, j, numOfRows, numOfCols, numOfBoxes);

                if (isRight && !isBottom)
                {
                   retMatrix[i, j] = origMatrix[i + 1, j];
                   if (lastRotation)
                   {
                      Console.Write(retMatrix[i, j]);
                      if (j == numOfCols - 1)
                         Console.WriteLine();
                      else
                         Console.Write(' ');
                   }
                   continue;
                }

                if (isBottom && !isLeft)
                {
                   retMatrix[i, j] = origMatrix[i, j - 1];
                   if (lastRotation)
                   {
                      Console.Write(retMatrix[i, j]);
                      if (j == numOfCols - 1)
                         Console.WriteLine();
                      else
                         Console.Write(' ');

                   }
                }
             }
          }
          return retMatrix;
       }

       public static string[,] GetGrid(int row, int col)
       {
          var retArray = new string[row, col];
          for (int lineNo = 0; lineNo < row; lineNo++)
          {
             var stringArray = Console.ReadLine().Split(' ').ToArray();
             for (int i = 0; i < stringArray.Length; i++)
			   {
			      retArray[lineNo, i] = stringArray[i];
			   }
          }
          return retArray;
       }

       public static string CellPos(int row, int col, int totalRows, int totalCols, int numOfBoxes)
       {
          var posText = new StringBuilder();
          if (IsInLeftCol(row, col, totalRows, totalCols, numOfBoxes))
             posText.Append("L");

          if (IsInRightCol(row, col, totalRows, totalCols, numOfBoxes))
             posText.Append("R");

          if (IsInTopRow(row, col, totalRows, totalCols, numOfBoxes))
             posText.Append("T");

          if (IsInBottomRow(row, col, totalRows, totalCols, numOfBoxes))
             posText.Append("B");

          return posText.ToString();
       }




       public static void FlippingBits()
       {
          var numTest = Convert.ToInt32(Console.ReadLine());
          for (int i = 0; i < numTest; i++)
          {
             var tempNum = Convert.ToUInt32( Console.ReadLine());
             var maxNum = Convert.ToUInt32(Math.Pow(2, 32) - 1);
             var retNum = tempNum ^ maxNum;
             Console.WriteLine(retNum);
          }
       }

       public static void CommonChild()
       {
          var firstString = Console.ReadLine().ToCharArray();
          var secondString = Console.ReadLine();

          int childLen = 0;

          for (int charPos = 0; charPos < firstString.Length; charPos++)
          {
             var pos = secondString.IndexOf(firstString[charPos]);
             if (pos > 0)
             {
                childLen++;
                secondString.Remove(pos, 1);
             }
          }
          Console.WriteLine(childLen);
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
