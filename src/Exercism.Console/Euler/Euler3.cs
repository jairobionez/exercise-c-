using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercism.Console.Euler
{

    public class Euler3
    {
        public static string LargestPrime(long N)
        {
            if (N < 10)
                return string.Empty;

            long largestPrime = 0;

            while(N % 2 == 0)
            {
                largestPrime = 2;
                N /= 2;
            }

            for (long i = 3; i * i <= N; i += 2)
            {
                while (N % i == 0)
                {
                    largestPrime = i;
                    N /= i;
                }
            }

            if (N > 2)
                largestPrime = N;

            return largestPrime.ToString();
        }

        private static bool IsPrimeNumber(long number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (long i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0) return false;
            }
            return true;
        }
    }

    [MemoryDiagnoser]
    public class Euler3Test
    {
        [Benchmark]
        public void Teste()
        {
            Euler3.LargestPrime(100000);
        }
    }
}
