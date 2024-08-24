using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Console.Euler
{
    public static class Euler4
    {

        public static string FindLargestPalindrome(long N)
        {
            if (N < 101101 || N > 1000000)
                return string.Empty;

            var palindromes = new List<long>();

            for(var min = 999; min >= 100; min--)
                for(var max = 999; max >= 100; max--)
                {
                    var teste = min * max;

                    if (teste < 101101)
                        continue;

                    if (teste.ToString()[0] == teste.ToString()[5] &&
                       teste.ToString()[1] == teste.ToString()[4] &&
                       teste.ToString()[2] == teste.ToString()[3] &&
                       teste < N)
                    {
                        palindromes.Add(teste);
                        break;
                    }
                }

            return palindromes.Max().ToString();
        }
    }
}
