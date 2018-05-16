using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringAnalyzercs
{
    class Program
    {
        static void Main(string[] args)
        {
            StringAnalyzer analyzer = new StringAnalyzer();
            analyzer.readString();
            Thread digitcount = new Thread(analyzer.digitCount);
            Thread vowelcount = new Thread(analyzer.vowelCount);
            Thread palindrome = new Thread(analyzer.isPalindrome);

            digitcount.Start();
            vowelcount.Start();
            palindrome.Start();

            digitcount.Join();
            vowelcount.Join();
            palindrome.Join();

            Console.WriteLine("Here are the results of string analysis");
            Console.WriteLine("Number of digits: {0}", analyzer.getDigits());
            Console.WriteLine("Number of vowels: {0}", analyzer.getVowels());
            Console.WriteLine("Is Palindrome? {0}", analyzer.getPalindrome());
            Console.ReadLine();


        }
    }
}
