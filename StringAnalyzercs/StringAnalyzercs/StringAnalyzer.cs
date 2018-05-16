using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalyzercs
{
    class StringAnalyzer
    {
        private String input;
        private int digits;
        private int vowels;
        private bool palindrome;

        public void readString()
        {
            Console.WriteLine("Please enter a string to analyze");
            String userin = Console.ReadLine();
            this.input = userin;

        }

        public void digitCount()
        {
            this.digits = 0;
            foreach(char c in input)
            {
                if (Char.IsDigit(c))
                    digits++;
            }
        }

        public void vowelCount()
        {
            this.vowels = 0;
            char temp;
            foreach( char c in input)
            {
                temp = Char.ToLower(c);
                if (temp == 'a' || temp == 'e' || temp == 'a' || temp == 'o' || temp == 'u')
                    vowels++;
            }
        }

        public void isPalindrome()
        {
            this.palindrome = false;
            string reverse = new string(input.ToCharArray().Reverse().ToArray());
            if (input.Equals(reverse))
                palindrome = true;
        }

        public int getDigits()
        {
            return this.digits;
        }

        public int getVowels()
        {
            return this.vowels;
        }
        public bool getPalindrome()
        {
            return this.palindrome;
        }
    }
}
