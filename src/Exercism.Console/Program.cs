using Exercism.Console;
using Exercism.Console.CryptoSquare;
using Exercism.Console.Lasagna;

namespace Exercism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://exercism.org/tracks/csharp/exercises/crypto-square
            //var cryptoSquare = CryptoSquare.Encoded("This is fun!");
            //var cryptoSquare2 = CryptoSquare.Encoded("If man was meant to stay on the ground, god would have given us roots.");
            //var cryptoSquare3 = CryptoSquare.Encoded("Chill out.");

            // https://exercism.org/tracks/csharp/exercises/lucians-luscious-lasagna
            //var remainingMinutres = Lasagna.RemainingMinutesInOven(10);
            //var elapsedTime = Lasagna.ElapsedTimeInMinutes(8, 10);

            //https://www.hackerrank.com/contests/projecteuler/challenges/euler051/problem?isFullScreen=true
            var primeDigits = PrimeDigitReplacements.InputNumbers(2, 1, 3);
            var primeDigits2 = PrimeDigitReplacements.InputNumbers(5, 2, 7);
            //var primeDigits = PrimeDigitReplacements.InputNumbers(6, 2, 7);
        }
    }
}