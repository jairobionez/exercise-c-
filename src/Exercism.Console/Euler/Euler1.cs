using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism.Console.Euler
{
    public static class Euler1
    {

        public static string Multiples(long N)
        {

            if (ApllyNContrainsts(N))
                return SumMultiples(N);

            return string.Empty;
        }

        static long SumMultiplesOfK(long k, long limit)
        {
            long p = (limit - 1) / k;  // Último múltiplo abaixo de 'N'
            return k * p * (p + 1) / 2;
        }

        public static string SumMultiples(long N)
        {
            long mult3 = SumMultiplesOfK(3, N);

            long mult5 = SumMultiplesOfK(5, N);

            long mult15 = SumMultiplesOfK(15, N);
            long totalSum = mult3 + mult5 - mult15;

            return totalSum.ToString();
        }

        public static bool ApplyTConstraints(List<long> T)
        {
            var sumT = T.Sum();
            if (sumT < 1 && sumT > Math.Pow(10, 5))
                return false;

            return true;
        }

        public static bool ApllyNContrainsts(long N)
        {
            if (N < 1 && N > Math.Pow(10, 9))
                return false;

            return true;
        }
    }
}
