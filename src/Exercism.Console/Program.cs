using BenchmarkDotNet.Running;
using Exercism.Console;
using Exercism.Console.CryptoSquare;
using Exercism.Console.Euler;
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
            //var primeDigits = Euler51.InputNumbers(2, 1, 3);
            //var primeDigits2 = Euler51.InputNumbers(5, 2, 7);
            //var primeDigits3 = Euler51.InputNumbers(7, 3, 7);
            //var primeDigits3 = Euler51.InputNumbers(4, 3, 4);
            //var primeDigits3 = Euler51.InputNumbers(6, 2, 5);

            //https://www.hackerrank.com/contests/projecteuler/challenges/euler001/problem?isFullScreen=true
            //var sumMultiples = Euler1.Multiples(10)

            //https://www.hackerrank.com/contests/projecteuler/challenges/euler002/problem?isFullScreen=true
            //var fibonacciSum = Euler2.GetFibonacciSum(10);

            //https://www.hackerrank.com/contests/projecteuler/challenges/euler004/problem?isFullScreen=true
            //var palindrome = Euler4.FindLargestPalindrome(800000);

            //https://www.hackerrank.com/contests/projecteuler/challenges/euler003/problem?isFullScreen=true
            //var largestPrime = BenchmarkRunner.Run<Euler3Test>();
            var largestPrime = Euler3.LargestPrime(123456789102);
        }
    }
}