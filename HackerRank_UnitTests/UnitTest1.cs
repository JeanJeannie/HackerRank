using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Text;
using HackerRank;

namespace HackerRank_UnitTests
{
   [TestClass]
   public class UnitTest1
   {
//      [TestMethod]
//      public void CheckPos()
//      {
//         int totalRow = 4;
//         int totalCol = 4;
//         var numOfBoxes = totalCol <= totalRow ? totalCol / 2 : totalRow / 2;


////         string[,] result = new string[totalRow, totalCol];
//         for (int i = 0; i < totalRow; i++)
//         {
//            for (int j = 0; j < totalCol; j++)
//            {
//               Console.Write(HackerRank.Solution.CellPos(i, j, totalRow, totalCol, numOfBoxes));
//               Console.WriteLine(":");
//            }
//            Console.WriteLine();
//         }
         
         
//         Assert.AreEqual("LT", "RT");
//      }


      [TestMethod]
      public void TestingRegEx()
      {
         var reg = new Regex(@".*[Hh][Aa][Cc][Kk][Ee][Rr][Rr][Aa][Nn][Kk].*");

         Assert.IsTrue(reg.IsMatch("blahhackerranksd"));
         Assert.IsTrue(reg.IsMatch("blahHACKERRANKsd"));
         Assert.IsTrue(reg.IsMatch("blahhackERranksd"));

      }

      [TestMethod]
      public void TestingRegExMatch()
      {
         var testNumber = @"111-222-1112223334";
         var countryCode = Regex.Match(testNumber, @"^(\d{1,3})[\-_]{1}\d{1,3}[\-_]{1}\d{4,10}$");
//         var localCode = Regex.Match(testNumber, @"\d{1-3}[-_](\d{1-3})[-_]\d{4-10}");
  //       var number = Regex.Match(testNumber, @"\d{1-3}[-_]\d{1-3}[-_](\d{4-10})");

         Assert.IsTrue(countryCode.Success, "country code not found");
    //     Assert.IsTrue(localCode.Success, "local code not found");
      //   Assert.IsTrue(number.Success, "number not found");
      }
   }
}
