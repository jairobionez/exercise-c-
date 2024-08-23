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
            var primeNumbers = new HashSet<long>();

            var combinations = Combinations(Enumerable.Range(1, (int)N - 2), (int)K);


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

                while (GetLengthUsingLog(initialNumber) == N)
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
                                var newNumber = ReplaceFamily(combination.ToList(), initialNumber.ToString(), replacementNumber);
                                if (IsPrimeNumber(newNumber) && !primeNumbers.Any(prime => prime == newNumber))
                                    primeNumbers.Add(newNumber);

                                stopLooping = primeNumbers.Count == L;
                                if (stopLooping) break;
                            };
                            if (stopLooping) break;
                            else
                                primeNumbers = new HashSet<long>();
                        };
                    }
                    if (stopLooping) break;
                    initialNumber++;
                }
            }

            return primeNumbers.OrderBy(x => x).ToList();
        }

        private static int GetLengthUsingLog(long number)
        {
            number = Math.Abs(number);
            if (number == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(number)) + 1;
        }

        private static long ReplaceFamily(List<int> positions, string number, long replacementNumber)
        {
            var charArray = number.ToCharArray();
            foreach (var position in positions)
            {
                charArray[position] = replacementNumber.ToString()[0];
            }
            return ToLong(new string(charArray));
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

        private static string GenerateInitialNumber(long N)
        {
            var builder = new StringBuilder();
            builder.Append('1');
            builder.Append('0', (int)N - 1);
            return builder.ToString();
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
