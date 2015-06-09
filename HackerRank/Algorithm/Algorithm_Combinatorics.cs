using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithm
{
   class Algorithm_Combinatorics
   {
      public static void Socks(int numOfTestCases)
      {
         for (int i = 0; i < numOfTestCases; i++)
         {
            var pairsOfSocks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(pairsOfSocks + 1);
         }
      }

      public static void Handshakes(int numOfTestCases)
      {
          for (int testNo = 0; testNo < numOfTestCases; testNo++)
          {
              var people = Convert.ToInt64(Console.ReadLine());
              long handshakes = 0;

              if (people >= 2)
              {
                  var half = Convert.ToInt64(Math.Ceiling((double)people / 2));
                  handshakes = ((half - 1) * people);
                  if (people % 2 == 0)
                  {
                      handshakes = handshakes + half;
                  }
              }
              Console.WriteLine(handshakes);
          }

      }
   }
}
