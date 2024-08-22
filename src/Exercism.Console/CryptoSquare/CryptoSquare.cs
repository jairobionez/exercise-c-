using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Text;

namespace Exercism.Console.CryptoSquare
{
    public static class CryptoSquare
    {
        public static string NormalizedPlaintext(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                return string.Empty;

            // Passo 1: Remover acentos
            string normalizedString = plaintext.Normalize(NormalizationForm.FormD);
            string stringWithoutAccents = new string(normalizedString
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            // Passo 2: Remover caracteres especiais e símbolos
            string result = Regex.Replace(stringWithoutAccents, @"[^a-zA-Z0-9\s]", "");

            return result.Trim().Replace(" ", string.Empty).ToLower();
        }

        public static string PlaintextSegments(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                return string.Empty;

            var columns = 0;
            var rows = 0;
            var wordSize = plaintext.Length;
            var sqrtCount = plaintext.Length;

            while (rows == 0)
            {
                var sqrt = Math.Sqrt(sqrtCount);
                if ((sqrt % 1 == 0 || sqrt % 2 == 0))
                {
                    if (sqrtCount - wordSize == 1 || sqrtCount == wordSize)
                        rows = (int)sqrt;
                    else if (sqrtCount > wordSize)
                        rows = (int)sqrt - 1;
                    else
                        rows = (int)sqrt + 1;

                    columns = (int)sqrt;
                }

                sqrtCount++;
            }

            var squareArray = new string[rows, columns];
            var codifiedArray = new string[columns];

            var stringCount = 0;

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    squareArray[r, c] = stringCount < wordSize ? plaintext[stringCount].ToString() : " ";
                    stringCount++;
                }
            }

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    codifiedArray[c] += squareArray[r, c];
                }
            }


            return string.Join(' ', codifiedArray);
        }

        public static string Encoded(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                return string.Empty;

            var normalizedText = NormalizedPlaintext(plaintext);

            return PlaintextSegments(normalizedText);
        }

        public static string Ciphertext(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
                return string.Empty;

            return Encoded(plaintext);
        }
    }
}
