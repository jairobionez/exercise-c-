using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Console.Euler
{
    public static class Euler2
    {
        //Sum only fibonacci number that starts with 1 and 2

        public static string GetFibonacciSum(long N)
        {
            var fibonacciNumbers = new List<long>();
            long fibonacciControl = 0;

            //for (var i = 1; fibonacciControl <= T; i++)
            //{
            //    if (i == 1 || i == 2)
            //    {
            //        fibonacciNumbers.Add(i);
            //        fibonacciControl = i;
            //    }
            //    else
            //    {
            //        fibonacciControl = fibonacciNumbers.TakeLast(2).Sum();
            //        fibonacciNumbers.Add(fibonacciControl);
            //    }
            //}


            while (true)
            {
                var listLength = fibonacciNumbers.Count;

                if (listLength == 1 || listLength == 2)
                {
                    fibonacciNumbers.Add(listLength);
                    fibonacciControl = listLength;
                }
                else
                {
                    fibonacciControl = fibonacciNumbers.TakeLast(2).Sum();
                    if (fibonacciControl >= N)
                        break;
                    fibonacciNumbers.Add(fibonacciControl);
                }
            }

            return fibonacciNumbers.Where(fibonacciNumber => fibonacciNumber % 2 == 0).Sum().ToString();
        }
    }
}
