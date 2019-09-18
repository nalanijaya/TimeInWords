using System;
using System.Collections.Generic;
using System.Text;

namespace CC5
{
    public class Program
    {
        static void Main(string[] args)
        {
            ClockTime(7, 29);
            Console.ReadLine();
        }

        private static void ClockTime(int firstNum, int secNum)
        {
            string timeInWords = "";
         
            string min = " minutes";

            if (secNum == 00)
            {
                timeInWords = (ConvertNumToWord(firstNum)).Append(" o' clock").ToString();
            }
            else if(secNum > 00 && secNum <= 30)
            {
                if(secNum == 01)
                {
                    min = " minute";
                }
                else if(secNum == 15 || secNum == 30)
                {
                    min = "";
                }

                timeInWords = (ConvertNumToWord(secNum)).Append(min + " past ").
                    Append(ConvertNumToWord(firstNum)).ToString();
            }
            else if (secNum > 30)
            {
                int remainder = 60 - secNum;
                if (remainder == 01)
                {
                    min = " minute";
                }
                else if (remainder == 15 || remainder == 30)
                {
                    min = "";
                }

                timeInWords = (ConvertNumToWord(60 - secNum)).Append(min + " to ").
                    Append(ConvertNumToWord(firstNum + 1)).ToString();
            }
            Console.WriteLine(timeInWords);
        }

        private static StringBuilder ConvertNumToWord(int number)
        {
            StringBuilder numberInWords = new StringBuilder();
            Dictionary<int, string> numWordDict = new Dictionary<int, string>
            {
               
                {01, "one" },
                {02, "two" },
                {03, "three" },
                {04, "four" },
                {05, "five" },
                {06, "six" },
                {07, "seven" },
                {08, "eight" },
                {09, "nine" },
                {10, "ten" },
                {11, "eleven" },
                {12, "twelve" },
                {13, "thirteen" },
                {14, "fourteen" },
                {15, "quarter" },
                {16, "sixteen" },
                {17, "seventeen" },
                {18, "eighteen" },
                {19, "nineteen" },
                {20, "twenty" },
                {30, "half" }
            };

            if(numWordDict.ContainsKey(number))
            {
                AppendWord(numWordDict, number, numberInWords);
            }
            else
            {
                int remainder = number % 20;
                if (numWordDict.ContainsKey(remainder))
                {
                    numberInWords.Append("twenty ");
                    AppendWord(numWordDict, remainder, numberInWords);
                }
            }
            return numberInWords;
        }
    
        private static void AppendWord(Dictionary<int, string> numWordDict, 
            int number, StringBuilder numberInWords)
        {
            
            foreach (var item in numWordDict)
            {
                if (number == item.Key)
                    numberInWords.Append(item.Value);

            }
        }
    }
}

