using System;
using System.Collections.Generic;

namespace LeetCode0017LetterCombinationsOfAPhoneNumber
{
    /*
        Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
        Return the answer in any order.
        A mapping of digit to letters (just like on the telephone buttons) is given below. 
        Note that 1 does not map to any letters.

        Example 1:
        Input: digits = "23"
        Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

        Example 2:
        Input: digits = ""
        Output: []

        Example 3:
        Input: digits = "2"
        Output: ["a","b","c"] 
    */
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var str in LetterCombinations(""))
            {
                Console.WriteLine(str);
            }         
        }

        public static IList<string> LetterCombinations(string digits) 
        {
            if (string.IsNullOrEmpty(digits)) return new List<string>();
            List<string> results = new List<string>();
            LetterCombinations(digits, 0 , new List<char>(), results);
            return results;
        }

        private static void LetterCombinations(string digits, int index, List<char> chars, List<string> results)
        {
            if (index == digits.Length) 
            {
                results.Add(new string(chars.ToArray()));
                return;
            }

            var letters = GetLetters(digits[index]);
            if (letters.Length == 0) 
            {
                LetterCombinations(digits, index + 1, new List<char>(chars), results);
            }

            foreach(char letter in letters)
            {
                List<char> copy = new List<char>(chars);
                copy.Add(letter);
                LetterCombinations(digits, index + 1, copy, results);
            }
        }

        private static char[] GetLetters(char digit)
        {
            if (digit == '2') return new char[]{'a', 'b', 'c'};
            if (digit == '3') return new char[]{'d', 'e', 'f'};
            if (digit == '4') return new char[]{'g', 'h', 'i'};
            if (digit == '5') return new char[]{'j', 'k', 'l'};
            if (digit == '6') return new char[]{'m', 'n', 'o'};
            if (digit == '7') return new char[]{'p', 'q', 'r', 's'};
            if (digit == '8') return new char[]{'t', 'u', 'v'};
            if (digit == '9') return new char[]{'w', 'x', 'y', 'z'};
            return new char[]{};
        }
    }
}
