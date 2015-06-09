using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithm
{
    public class Algorithm_Sorting
    {
        public static void insertionSort(int[] ar)
        {
            var array = ar; //Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s.ToString())).ToArray();
            var arraySize = ar.Length;

            var tempVar = array[arraySize - 1];
            var found = false;
            for (int i = arraySize - 2; i >= 0; i--)
            {
                if (array[i] > tempVar)
                {
                    array[i + 1] = array[i];
                }
                else
                {
                    array[i + 1] = tempVar;
                    found = true;
                    break;
                }
                Console.WriteLine(string.Join(" ", array));
            }

            if (!found)
            {
                array[0] = tempVar;
            }
            Console.WriteLine(string.Join(" ", array));
        }

        public static void TutorialIntro()
        {
            var valueToFind = Convert.ToInt64(Console.ReadLine());
            var numOfElements = Convert.ToInt64(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();

            for (int i = 0; i < numOfElements; i++)
            {
                if (array[i] == valueToFind)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }


    }
}
