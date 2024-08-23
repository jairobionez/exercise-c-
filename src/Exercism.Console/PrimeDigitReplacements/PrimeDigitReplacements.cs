using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Console
{
    public static class PrimeDigitReplacements
    {

        public static List<long> InputNumbers(long N, long K, long L)
        {
            var primeNumbers = new List<long>();
            //var a = IsPrimeNumber(N);

            var combinations = Combinations(Enumerable.Range(1, (int)N - 1), (int)K);


            if (ApplyConstraints(N, K, L))
            {
                long initialNumber = 0;

                var digits = N;
                var noReplacements = K;
                var noPrimeNumber = L;

                initialNumber = ToLong(GenerateInitialNumber(N));

                var currentNumber = initialNumber;
                var firstFamilyNumber = 0l;
                var stopLooping = false;

                while (initialNumber.ToString().Count() == N)
                {
                    if (IsPrimeNumber(initialNumber))
                    {
                        firstFamilyNumber = initialNumber;
                        
                        foreach (var combination in combinations)
                        {
                            primeNumbers.Add(initialNumber);
                            initialNumber = firstFamilyNumber;
                            for (var replacementNumber = 1; replacementNumber <= 9; replacementNumber++)
                            {
                                var newNumber = ReplaceFamily(combination.ToList(), initialNumber, replacementNumber);
                                if (IsPrimeNumber(newNumber) && !primeNumbers.Any(prime => prime == newNumber))
                                    primeNumbers.Add(newNumber);

                                stopLooping = primeNumbers.Count == L;
                                if (stopLooping) break;
                            };
                            if (stopLooping) break;
                            else
                                primeNumbers = new List<long>();
                        };
                    }
                    if (stopLooping) break;
                    initialNumber++;
                }
            }

            return primeNumbers.OrderBy(x => x).ToList();
        }

        private static long ReplaceFamily(List<int> positions, long number, long replacementNumber)
        {
            var numberStr = number.ToString();
            for (var i = 0; i < positions.Count; i++)
                numberStr = numberStr.ToString().Remove(positions[i], 1).Insert(positions[i], replacementNumber.ToString());
            return ToLong(numberStr);
        }

        private static bool IsPrimeNumber(long number)
        {
            int count = 0;

            for (var i = 1; i <= number; i++)
            {
                if (number <= 1)
                    count = 3;

                if (number % i == 0)
                    count++;

                if (count == 3)
                    break;
            }

            return count == 2;
        }

        private static string GenerateInitialNumber(long N)
        {
            var initialNumberStr = "";

            for (var i = 1; i <= N; i++)
            {
                if (i == 1)
                    initialNumberStr += "1";
                else
                    initialNumberStr += "0";
            }

            return initialNumberStr;
        }

        private static bool ApplyConstraints(long N, long K, long L)
        {
            if (N < 2 || N > 7)
                return false;

            if (K < 1 || K > N)
                return false;

            if (L < 1 || L > 8)
                return false;

            return true;
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elementos, int k)
        {
            if (k == 0) return new[] { new T[0] };

            return GetCombinationsRecursive(elementos, k);
        }

        private static IEnumerable<IEnumerable<T>> GetCombinationsRecursive<T>(IEnumerable<T> elementos, int k)
        {
            if (k == 0) return new[] { new T[0] };

            return elementos.SelectMany((e, i) =>
                GetCombinationsRecursive(elementos.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));
        }

        private static long ToLong(string number)
        {
            return Convert.ToInt64(number);
        }
    }
}
