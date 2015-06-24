using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace HackerRank_UnitTests
{
   [TestClass]
   public class UnitTest1
   {
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
